
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Infrastructure.Background;
using System;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services;

public class UserService(IUserRepository repository, IJwtProvider jwtProvider, IPasswordHasher passwordHash, IQRProvider qRProvider, IEmailProvider emailProvider,
    IRegistrarUserBackground registrarUserBackground)
{
    private readonly IUserRepository _userRepository = repository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IPasswordHasher _passwordHasher = passwordHash;
    private readonly IQRProvider _qrProvider = qRProvider;
    private readonly IEmailProvider _emailProvider = emailProvider;
    private readonly IRegistrarUserBackground _registrarUserBackground = registrarUserBackground;

    public async Task<string> LogInUser(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);
        if (!_passwordHasher.Verify(password, user.Password ?? throw new ServerException(ErrorCode.LoginUser, $"Don`t found password user with id: {user.Id}.")))
            throw new RequestException(ErrorCode.LoginUser, $"Incorrect password or email.");
        return GenerateToken(user.Id);
    }

    public async Task<uint> VerifyEmail(string email)
    {
        if (await _userRepository.CheckUserByEmail(email))
            throw new RequestException(ErrorCode.RegistrationError, $"User with email {email} already exsists.");

        if (_registrarUserBackground.IsEmailInRegistration(email))
            throw new RequestException(ErrorCode.RegistrationError, "The code has already been sent to this email.");
        var (numberRegistration, code) = _registrarUserBackground.AddNewEmailRegistration(email);
        
        var exception = _emailProvider.SendCodeEmail(email, code);
        if (exception != null)
        {
            _registrarUserBackground.PopRegistrationEmail(numberRegistration);
            throw exception;
        }
        return numberRegistration;
    }

    public void VerifyCodeEmail(uint numberRegistration, string code)
    {
        if (_registrarUserBackground.CheckEmailCode != null)
            _registrarUserBackground.CheckEmailCode(numberRegistration, code);
        else
            throw new ServerException(ErrorCode.RegistrationError, $"There is no access to the back service throw facade {nameof(RegistrarUserFacade)}.");
    }

    public async Task<string> RegisterUser(uint numberRegistration, User user)
    {
        user.Password = _passwordHasher.HashPassword(user.Password!);
        if (_registrarUserBackground.GetVerificationEmailByNumberRegistration(numberRegistration) is VerificationEmail verificationEmail)
        {
            user.Email = verificationEmail.Email;
            var userId = await _userRepository.Add(user);
            return GenerateToken(userId);
        }
        throw new RequestException(ErrorCode.RegistrationError, "Try again, send an Email again.");
    }

    public async Task EditUser(ClaimsPrincipal claimsPrincipal, User editUser)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        await _userRepository.Edit(userId, editUser);
    }

    public async Task DeleteUser(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        await _userRepository.Delete(userId);
    }

    public string GetQRCode(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var encryptUserQR = _qrProvider.EncryptQR(new UserQR { IdUser = userId});
        return encryptUserQR;
    }

    public async Task<User> GetUser(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var user = await _userRepository.GetById(userId);
        return user;
    }

    private string GenerateToken(Guid userId)
    {
        var userClaims = _jwtProvider.SetUserId(userId.ToString());
        return _jwtProvider.GenerateNewToken(userClaims);
    }

    public string SendCodeAgain(uint numberRegistration)
    {
        if (_registrarUserBackground.GetVerificationEmailByNumberRegistration(numberRegistration) is VerificationEmail verificationEmail)
        {
            if (verificationEmail.StartValidation.AddMinutes(1) > DateTime.Now)
                throw new RequestException(ErrorCode.RegistrationError, "The time has not expired yet to repeat the email validation.");
            string code = _registrarUserBackground.RegenerationCode(numberRegistration);
            
            var exception = _emailProvider.SendCodeEmail(verificationEmail.Email, code);
            if (exception != null)
            {
                _registrarUserBackground.PopRegistrationEmail(numberRegistration);
                throw exception;
            }
        }
        throw new RequestException(ErrorCode.RegistrationError, "Try again, send an Email again.");
    }
}
