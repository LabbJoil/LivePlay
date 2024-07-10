
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Infrastructure.Background;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services;

public class UserService(IUserRepository repository, IJwtProvider jwtProvider, IPasswordHasher passwordHash, IQRProvider qRProvider, IEmailProvider emailProvider,
    BackgroundFacade backgroundFacade)
{
    private readonly IUserRepository _userRepository = repository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IPasswordHasher _passwordHasher = passwordHash;
    private readonly IQRProvider _qrProvider = qRProvider;
    private readonly IEmailProvider _emailProvider = emailProvider;
    private readonly IRegistrarUserBackground _backgroundFacade = backgroundFacade.RegistrarUserBackground;

    public async Task<(string, Role[])> LoginUser(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);
        if (!_passwordHasher.Verify(password, user.Password ?? throw new ServerException(ErrorCode.LoginUser, $"Don`t found password user with id: {user.Id}.")))
            throw new RequestException(ErrorCode.LoginUser, $"Incorrect password or email.");
        return (GenerateToken(user.Id), user.Roles);
    }

    public async Task<uint> VerifyEmail(string email)
    {
        if (await _userRepository.CheckUserByEmail(email))
            throw new RequestException(ErrorCode.RegistrationError, $"User with email {email} already exsists.");

        if (_backgroundFacade.IsEmailInRegistration(email))
            throw new RequestException(ErrorCode.RegistrationError, "The code has already been sent to this email.");
        var (numberRegistration, code) = _backgroundFacade.AddNewEmailRegistration(email);
        
        var exception = _emailProvider.SendCodeEmail(email, code);
        if (exception != null)
        {
            _backgroundFacade.PopRegistrationEmail(numberRegistration);
            throw exception;
        }
        return numberRegistration;
    }

    public void VerifyCodeEmail(uint numberRegistration, string code)
    {
        if (_backgroundFacade.CheckEmailCode != null)
            _backgroundFacade.CheckEmailCode(numberRegistration, code);
        else
            throw new ServerException(ErrorCode.RegistrationError, $"There is no access to the back service throw facade {nameof(BackgroundFacade)}.");
    }

    public async Task RegisterUser(uint numberRegistration, User user)
    {
        user.Password = _passwordHasher.HashPassword(user.Password!);
        if (_backgroundFacade.GetVerificationEmailByNumberRegistration(numberRegistration) is VerificationEmail verificationEmail)
        {
            if (verificationEmail.IsApproveEmailCode)
                throw new RequestException(ErrorCode.RegistrationError, "The code sent to the email has not yet been confirmed", $"NumberRegistration - {numberRegistration}");

            user.Email = verificationEmail.Email;
            await _userRepository.Add(user);
            return;
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

    public async Task<int> GetPoints(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var user = await _userRepository.GetById(userId);
        return user.Points;
    }

    private string GenerateToken(Guid userId)
    {
        var userClaims = _jwtProvider.SetUserId(userId.ToString());
        return _jwtProvider.GenerateNewToken(userClaims);
    }

    public void SendCodeAgain(uint numberRegistration)
    {
        if (_backgroundFacade.GetVerificationEmailByNumberRegistration(numberRegistration) is VerificationEmail verificationEmail)
        {
            if (verificationEmail.StartValidation.AddMinutes(1) > DateTime.Now)
                throw new RequestException(ErrorCode.RegistrationError, "The time has not expired yet to repeat the email validation.");
            string code = _backgroundFacade.RegenerationCode(numberRegistration);
            
            var exception = _emailProvider.SendCodeEmail(verificationEmail.Email, code);
            if (exception != null)
            {
                _backgroundFacade.PopRegistrationEmail(numberRegistration);
                throw exception;
            }
            return;
        }
        throw new RequestException(ErrorCode.RegistrationError, "Try again, send an Email again.");
    }
}
