﻿
namespace LivePlay.Server.Application.Interfaces;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool Verify(string password, string dbHashPassword);
}
