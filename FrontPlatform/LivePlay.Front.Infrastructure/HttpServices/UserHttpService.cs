
using LivePlay.Front.Core.Enums;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure.Abstracts;
using LivePlay.Front.Infrastructure.Contracts.Requests.UserRequests;
using LivePlay.Front.Infrastructure.Contracts.Responses;

namespace LivePlay.Front.Infrastructure.HttpServices;

public class UserHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory)
{
    protected override string BaseRoute => "user";

    public async Task<(Role[], DisplayError?)> Login(string email, string password)
    {
        const string route = "/login";
        (string, string)[] sendParams = [
            (nameof(email), email),
            (nameof(password), password)
            ];
        var response = await _httpProvider.Get(BaseRoute + route, sendParams);

        if (response.IsSuccess)
        {
            var (loginResponse, error) = ParseResponse<LoginResponse>(response);
            if (loginResponse != null)
            {
                _httpProvider.SetToken(loginResponse.Token);
                return (loginResponse.Role.Select(Enum.Parse<Role>).ToArray(), null);
            }
            return ([], error);
        }
        else
            return ([], ParseError(response.ResponseData, response.Error));
    }

    public async Task<(uint, DisplayError?)> VerifyEmail(string email)
    {
        const string route = "/verifyemail";
        var response = await _httpProvider.Get(BaseRoute + route, (nameof(email), email));
        if (response.IsSuccess)
            return ParseResponse<uint>(response);
        else
            return (default, ParseError(response.ResponseData, response.Error));
    }

    public async Task<DisplayError?> VerifyCodeEmail(uint numberRegistration, string code)
    {
        const string route = "/verifycodeemail";
        (string, string)[] sendParams = [
            (nameof(numberRegistration), numberRegistration.ToString()),
            (nameof(code), code)
            ];

        var response = await _httpProvider.Get(BaseRoute + route, sendParams);
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }

    public async Task<DisplayError?> Registration(uint numberRegistration, User user)
    {
        const string route = "/registration";
        var registrationUser = _mapper.Map<RegistrationUserRequest>(user);
        var response = await _httpProvider.Post(BaseRoute + route, registrationUser, (nameof(numberRegistration), numberRegistration.ToString()));
        if (response.IsSuccess)
        {
            var (token, error) = ParseResponse<string>(response);
            if (error == null && token != null)
                _httpProvider.SetToken(token);
            else
                return error;
            return null;
        }
        else
            return ParseError(response.ResponseData, response.Error);
    }

    public async Task<DisplayError?> SendCodeAgain(uint numberRegistratrtion)
    {
        const string route = "/sendcodeagain";

        var response = await _httpProvider.Get(BaseRoute + route, (nameof(numberRegistratrtion), numberRegistratrtion.ToString()));
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }
}
