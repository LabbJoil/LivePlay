
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Models;
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

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var rum in NewRegistrationUsers)
                if (rum.Value.StartValidation.AddMinutes(maxTimeSaveEmailValidation) < DateTime.Now)
                    NewRegistrationUsers.Remove(rum.Key);
            
            await Task.Delay(millisecondsDelay, stoppingToken);
        }
    }

    private bool CheckCodeRegistrationUser(uint numberRegistration, string checkCode)
    {
        if (NewRegistrationUsers.TryGetValue(numberRegistration, out RegistrationUserModel? registrationUser) && registrationUser != null)
        {
            if (registrationUser.EmailCode == checkCode && !registrationUser.IsApproveEmailCode)
            {
                registrationUser.IsApproveEmailCode = true;
                return true;
            }
        }
        throw new RequestException("Время верификации email истекло", $"Номер регистрации - {numberRegistration}, код проверки - {checkCode}");
    }


    private uint AddNewRegistrationUser(User newUser)
    {
        var numberRegistration = GetNumberRegistration();
        string code = GenerateNewCode();
        EmailProvider.SendCodeEmail(newUser.Email ?? throw new Exception("Email is not provided"), code);

        var registrationUser = new RegistrationUserModel {
            RegistrationUser = newUser,
            EmailCode = code
        };

        NewRegistrationUsers[numberRegistration] = registrationUser;
        return numberRegistration;
    }

    private void IsEmailInRegistration(string email)
    {
        foreach(RegistrationUserModel rum in NewRegistrationUsers.Values)
            if (rum.RegistrationUser.Email == email && rum.StartValidation.AddMinutes(1) < DateTime.Now)
                throw new Exception("The time has not expired yet to repeat the email validation");
    }

    private uint GetNumberRegistration()
    {
        for (uint nr = 1; nr < uint.MaxValue; nr++)
            if (!NewRegistrationUsers.TryGetValue(nr, out var _))
                return nr;

        throw new Exception("Something wrong. All numberRegistration busy, but it is uint.");
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
        public required User RegistrationUser { get; set; }
        public required string EmailCode { get; set; }
        public DateTime StartValidation { get; } = DateTime.Now;
        public bool IsApproveEmailCode { get; set; } = false;
    }
}