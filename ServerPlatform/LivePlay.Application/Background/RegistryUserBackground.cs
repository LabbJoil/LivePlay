
using LivePlay.Core.Models;
using LivePlay.Infrastructure.Other;
using Microsoft.Extensions.Hosting;

namespace LivePlay.Application.Background;

public class RegistryUserBackground(EmailProvider emailProvider) : BackgroundService
{
    private readonly EmailProvider _emailProvider = emailProvider;
    private readonly Dictionary<uint, RegistrationUserModel> NewRegistrationUsers = [];

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int maxTimeSaveEmailValidation = 20;
        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var rum in NewRegistrationUsers)
                if (rum.Value.StartValidation.AddMinutes(maxTimeSaveEmailValidation) < DateTime.Now)
                    NewRegistrationUsers.Remove(rum.Key);
            
            await Task.Delay(1500, stoppingToken);
        }
    }

    public bool CheckCodeRegistrationUser(uint numberRegistration, int[] checkCode)
    {
        if (NewRegistrationUsers.TryGetValue(numberRegistration, out RegistrationUserModel? registrationUser) && registrationUser != null)
        {
            if (registrationUser.EmailCode == checkCode && !registrationUser.IsApproveEmailCode)
            {
                registrationUser.IsApproveEmailCode = true;
                return true;
            }
        }
        throw new Exception("Время верификации email истекло");
    }


    public uint AddNewRegistrationUser(User newUser)
    {
        var numberRegistration = GetNumberRegistration();
        int[] code = GenerateNewCode();
        _emailProvider.SendEmail(newUser.Email ?? throw new Exception("Email is not provided"), code);

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

    private static int[] GenerateNewCode()
    {
        const int codeMasLength = 4;
        var rand = new Random();
        var newCodeMas = new int[codeMasLength];

        for (int i = 0; i < codeMasLength; i++)
            newCodeMas[i] = rand.Next(0, 10);
        return newCodeMas;
    }

    private class RegistrationUserModel
    {
        public required User RegistrationUser { get; set; }
        public required int[] EmailCode { get; set; }
        public DateTime StartValidation { get; } = DateTime.Now;
        public bool IsApproveEmailCode { get; set; } = false;
    }
}