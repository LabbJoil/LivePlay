﻿
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Infrastructure.Background;

namespace LivePlay.Server.Application.Interfaces;

public interface IRegistrarUserBackground
{
    public VerificationEmail? GetVerificationEmailByNumberRegistration(uint numberRegistration);
    public RequestException? CheckEmailCode(uint numberRegistration, string checkCode);
    public ((uint, string)?, RequestException?) AddNewEmailRegistration(string email);
    public void PopRegistrationEmail(uint numberRegistration);
    public string RegenerationCode(uint numberRegistration);
}
