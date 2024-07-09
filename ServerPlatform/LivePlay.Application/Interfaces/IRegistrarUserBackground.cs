
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Infrastructure.Background;

namespace LivePlay.Server.Application.Interfaces;

public interface IRegistrarUserBackground
{
    public static IRegistrarUserBackground? Instance { get; }
    public VerificationEmail? GetVerificationEmailByNumberRegistration(uint numberRegistration);
    public RequestException? CheckEmailCode(uint numberRegistration, string checkCode);
    public (uint, string) AddNewEmailRegistration(string email);
    public void PopRegistrationEmail(uint numberRegistration);
    public string RegenerationCode(uint numberRegistration);
    public bool IsEmailInRegistration(string email);
}
