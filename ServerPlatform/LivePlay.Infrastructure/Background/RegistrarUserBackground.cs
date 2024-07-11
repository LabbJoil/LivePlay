
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using Microsoft.Extensions.Hosting;

namespace LivePlay.Server.Infrastructure.Background;

public partial class RegistrarUserBackground : BackgroundService, IRegistrarUserBackground
{
    private readonly Dictionary<uint, VerificationEmail> _newRegistrationUsers = [];

    public RegistrarUserBackground(BackgroundFacade backgroundFacade)
    {
        backgroundFacade.RegistrarUserBackground = this;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int maxTimeSaveEmailValidation = 20;
        const int millisecondsDelay = 1500;

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var rum in _newRegistrationUsers)
                if (rum.Value.StartValidation.AddMinutes(maxTimeSaveEmailValidation) < DateTime.Now)
                    _newRegistrationUsers.Remove(rum.Key);
            await Task.Delay(millisecondsDelay, stoppingToken);
        }
    }

    public RequestException? CheckEmailCode(uint numberRegistration, string checkCode)
    {
        if (GetVerificationEmailByNumberRegistration(numberRegistration) is VerificationEmail verificationEmail)
        {
            if (verificationEmail.Code != checkCode)
                return new(ErrorCode.RegistrationError, $"The code was entered incorrectly", $"Registration number - {numberRegistration}, verification code - {checkCode}");
            if (verificationEmail.IsApproveEmailCode)
                return new(ErrorCode.RegistrationError, $"The code has already been applied", $"Registration number - {numberRegistration}, verification code - {checkCode}");
            return null;
        }
        return new RequestException(ErrorCode.RegistrationError, $"Email verification time has expired", $"Registration number - {numberRegistration}, verification code - {checkCode} not found");
    }

    public (uint, string) AddNewEmailRegistration(string email)
    {
        var numberRegistration = GetNewNumberRegistration();
        string code = GenerateNewCode();

        var registrationUser = new VerificationEmail
        {
            Email = email,
            Code = code
        };

        _newRegistrationUsers[numberRegistration] = registrationUser;
        return (numberRegistration, code);
    }

    public void PopRegistrationEmail(uint numberRegistration)
    {
        var isDeleted = _newRegistrationUsers.Remove(numberRegistration);
        if (!isDeleted)
            throw new RequestException(ErrorCode.RegistrationError, $"The registration number could not be found.", $"Registration number - {numberRegistration}");
    }

    public string RegenerationCode(uint numberRegistration)
    {
        if (GetVerificationEmailByNumberRegistration(numberRegistration) is VerificationEmail verificationEmail)
        {
            var newCode = GenerateNewCode();
            verificationEmail.Code = newCode;
            return newCode;
        }
        throw new RequestException(ErrorCode.RegistrationError, $"Email verification time has expired", $"Registration number - {numberRegistration} not found");
    }

    public bool IsEmailInRegistration(string email)
    {
        foreach (var rum in _newRegistrationUsers.Values)
            if (rum.Email == email)
                return true;
        return false;
    }

    public VerificationEmail? GetVerificationEmailByNumberRegistration(uint numberRegistration)
    {
        _newRegistrationUsers.TryGetValue(numberRegistration, out VerificationEmail? registrationUser);
        return registrationUser;
    }

    private uint GetNewNumberRegistration()
    {
        for (uint nr = 1; nr < uint.MaxValue; nr++)
            if (!_newRegistrationUsers.TryGetValue(nr, out var _))
                return nr;
        throw new ServerException(ErrorCode.ServerError, "Something wrong. All numberRegistration busy, but it is uint.");
    }

    private static string GenerateNewCode()
    {
        const int codeMasLength = 4;
        var rand = new Random();
        var newCode = string.Empty;

        for (int i = 0; i < codeMasLength; i++)
            newCode += rand.Next(0, 10);
        return newCode;
    }
}