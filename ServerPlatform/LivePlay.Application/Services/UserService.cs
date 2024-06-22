
using LivePlay.Server.Application.CustomExceptions;
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Core.Interfaces;
using LivePlay.Server.Core.Models;
using System.Security.Claims;

namespace LivePlay.Server.Application.Services;

public class UserService(IUserRepository repository, IJwtProvider jwtProvider, IPasswordHasher passwordHash, IQRProvider qRProvider, RegistrarUserFacade registrarUserFacade)
{
    private readonly IUserRepository _userRepository = repository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IPasswordHasher _passwordHasher = passwordHash;
    private readonly IQRProvider _qrProvider = qRProvider;
    private readonly RegistrarUserFacade _registrarUserFacade = registrarUserFacade;

    public async Task<string> LogInUser(string email, string password)
    {
        var (user, userId) = await _userRepository.GetUserByEmail(email);
        if (!_passwordHasher.Verify(password, user.Password ?? throw new ServerException(ErrorCode.LoginUser, $"Don`t found password user with id: {userId}")))
            throw new RequestException(ErrorCode.LoginUser, $"Incorrect password or email");
        return GenerateToken(userId);
    }

    public async Task<uint> VerifyEmail(string email)
    {
        if (await _userRepository.CheckUserByEmail(email))
            throw new RequestException(ErrorCode.VerifyEmailError, $"User with email {email} already exsists");

        var enterNumber = _registrarUserFacade.AddNewRegistrationUser?.Invoke(email)
            ?? throw new ServerException(ErrorCode.VerifyEmailError, $"There is no access to the back service throw facade {nameof(RegistrarUserFacade)}");
        return enterNumber;
    }

    public void VerifyCodeEmail(uint numberRegistration, string code)
    {
        if (_registrarUserFacade.CheckCodeRegistrationUser != null)
            _registrarUserFacade.CheckCodeRegistrationUser.Invoke(numberRegistration, code);
        else
            throw new ServerException(ErrorCode.VerifyEmailError, $"There is no access to the back service throw facade {nameof(RegistrarUserFacade)}");
    }

    public async Task<string> RegisterUser(uint numberRegistration, User user)
    {
        //user.Password = _passwordHasher.HashPassword(user.Password!);
        //user.Email = _registrarUserFacade.GetRegistrationUser?.Invoke(numberRegistration)
        //    ?? throw new ServerException(ErrorCode.VerifyEmailError, $"There is no access to the back service throw facade {nameof(RegistrarUserFacade)}");
        var userId = await _userRepository.AddUser(user);
        return GenerateToken(userId);
    }

    public async Task EditUser(ClaimsPrincipal claimsPrincipal, User editUser)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        await _userRepository.EditUser(userId, editUser);
    }

    public async Task DeleteUser(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        await _userRepository.DeleteUser(userId);
    }

    public string GetQRCode(ClaimsPrincipal claimsPrincipal)
    {
        var userId = _jwtProvider.GetUserId(claimsPrincipal);
        var encryptUserQR = _qrProvider.EncryptQR(new UserQR { IdUser = userId});
        return encryptUserQR;
    }

    private string GenerateToken(Guid userId)
    {
        var userClaims = _jwtProvider.SetUserId(userId.ToString());
        return _jwtProvider.GenerateNewToken(userClaims);
    }
}
