
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
        var token = GenerateToken(user.Id);
        return (token, user.Roles);
    }

    public async Task<uint> VerifyEmail(string email)
    {
        if (await _userRepository.CheckUserByEmail(email))
            throw new RequestException(ErrorCode.RegistrationError, $"User with email {email} already exsists.");

        var (code_NumberRegistration, error) = _backgroundFacade.AddNewEmailRegistration(email);
        if (error != null)
            throw error;

        if (code_NumberRegistration is (uint numberRegistration, string code))
        {
            var exception = _emailProvider.SendCodeEmail(email, code);
            if (exception != null)
            {
                _backgroundFacade.PopRegistrationEmail(numberRegistration);
                throw exception;
            }
            return numberRegistration;
        }
        throw new ServerException(ErrorCode.RegistrationError, $"code_NumberRegistration in {nameof(UserService)} - {nameof(VerifyEmail)} don't parse, but error no");
    }

    public void VerifyCodeEmail(uint numberRegistration, string code)
    {
        var error = _backgroundFacade.CheckEmailCode(numberRegistration, code);
        if (error != null)
            throw error;
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

    public async Task<Role[]> GetUserRoles(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var user = await _userRepository.GetById(userId);
        return user.Roles;
    }

    private string GenerateToken(Guid userId)
    {
        var userClaims = _jwtProvider.SetUserId(userId.ToString());
        return _jwtProvider.GenerateNewToken(userClaims);
    }
}
