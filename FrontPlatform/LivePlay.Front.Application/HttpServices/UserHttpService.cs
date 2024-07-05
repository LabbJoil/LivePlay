
using LivePlay.Front.Application.Contracts.Responses;
using LivePlay.Front.Application.Interfaces;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.Application.HttpServices;

public class UserHttpService(IServiceScopeFactory serviceScopeFactory) : BaseHttpServise(serviceScopeFactory, "user")
{
    public async Task<(uint, DisplayError?)> VerifyEmail(string email)
    {
        const string route = "/verifyemail";
        var response = await _httpProvider.Get(_baseRoute+route, (nameof(email), email));
        return ParseResponse<uint>(response);
    }

    public async Task<DisplayError?> VerifyCodeEmail(uint numberRegistratrtion, string code)
    {
        const string route = "/verifycodeemail";
        (string, string)[] sendParams = [
            (nameof(numberRegistratrtion), numberRegistratrtion.ToString()),
            (nameof(code), code)
            ];

        var response = await _httpProvider.Get(_baseRoute + route, sendParams);
        if (response.IsSuccess)
            return null;
        else
            return ParseError(response.ResponseData, response.Error);
    }
}
