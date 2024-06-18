
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Infrastructure.Providers;
using Microsoft.Extensions.Hosting;

namespace LivePlay.Server.Infrastructure.Background;

public class RegistrarUserBackground(EmailProvider emailProvider, RegistrarUserFacade backgroundServiceFacade) : BackgroundService, IRegistryUserBackground
{
    private readonly EmailProvider EmailProvider = emailProvider;
    private readonly RegistrarUserFacade BackFacade = backgroundServiceFacade;
    private readonly Dictionary<uint, RegistrationUserModel> NewRegistrationUsers = [];

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int maxTimeSaveEmailValidation = 20;
        const int millisecondsDelay = 1500;

        BackFacade.CheckCodeRegistrationUser = CheckCodeRegistrationUser;
        BackFacade.AddNewRegistrationUser = AddNewRegistrationUser;
        BackFacade.GetRegistrationUser = GetVerifityEmail;

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var rum in NewRegistrationUsers)
                if (rum.Value.StartValidation.AddMinutes(maxTimeSaveEmailValidation) < DateTime.Now)
                    NewRegistrationUsers.Remove(rum.Key);
            
            await Task.Delay(millisecondsDelay, stoppingToken);
        }
    }

    private string GetVerifityEmail(uint numberRegistration)
    {
        foreach (var rum in NewRegistrationUsers)
            if (rum.Key == numberRegistration)
                return rum.Value.Email;
        throw new RequestException(ErrorCode.VerifyEmailError, $"The registration email could not be received.", $"Registration number - {numberRegistration}");
    }

    private void CheckCodeRegistrationUser(uint numberRegistration, string checkCode)
    {
        if (NewRegistrationUsers.TryGetValue(numberRegistration, out RegistrationUserModel? registrationUser) && registrationUser != null)
            if (registrationUser.EmailCode == checkCode && !registrationUser.IsApproveEmailCode)
            {
                registrationUser.IsApproveEmailCode = true;
                return;
            }
        throw new RequestException(ErrorCode.VerifyEmailError, $"Email verification time has expired", $"Registration number - {numberRegistration}, verification code - {checkCode}");
    }


    private uint AddNewRegistrationUser(string email)
    {
        IsEmailInRegistration(email);
        var numberRegistration = GetNumberRegistration();
        string code = GenerateNewCode();
        EmailProvider.SendCodeEmail(email, code);

        var registrationUser = new RegistrationUserModel {
            Email = email,
            EmailCode = code
        };

        NewRegistrationUsers[numberRegistration] = registrationUser;
        return numberRegistration;
    }

    private void IsEmailInRegistration(string email)
    {
        foreach(RegistrationUserModel rum in NewRegistrationUsers.Values)
            if (rum.Email == email && rum.StartValidation.AddMinutes(1) < DateTime.Now)
                throw new RequestException(ErrorCode.VerifyEmailError, "The time has not expired yet to repeat the email validation");
    }

    private uint GetNumberRegistration()
    {
        for (uint nr = 1; nr < uint.MaxValue; nr++)
            if (!NewRegistrationUsers.TryGetValue(nr, out var _))
                return nr;

        throw new ServerException(ErrorCode.ServerError, "Something wrong. All numberRegistration busy, but it is uint.");
    }

    private static string GenerateNewCode()
    {
        const int codeMasLength = 4;
        var rand = new Random();
        var newCode = "";

        for (int i = 0; i < codeMasLength; i++)
            newCode += rand.Next(0, 10);
        return newCode;
    }

    private class RegistrationUserModel
    {
        public required string Email { get; set; }
        public required string EmailCode { get; set; }
        public DateTime StartValidation { get; } = DateTime.Now;
        public bool IsApproveEmailCode { get; set; } = false;
    }
}