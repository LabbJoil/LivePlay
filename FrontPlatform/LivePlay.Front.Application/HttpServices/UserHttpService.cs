
using LivePlay.Front.Application.Contracts.Responses;
using LivePlay.Front.Application.Interfaces;

namespace LivePlay.Front.Application.HttpServices;

public class UserHttpService(IHttpProvider httpProvider) : IHttpServise
{
    private IHttpProvider HttpProvider { get; set; } = httpProvider;
    public string BaseRoute { get; } = "user";

    public async Task<BaseResponse<uint>> VerifyEmail(string email)
    {
        const string route = "/verifyemail";
        var response = await HttpProvider.Get<uint>(BaseRoute+route, (nameof(email), email));
        return response;
    }

    public async Task<BaseResponse<object>> VerifyCodeEmail(uint numberRegistratrtion, string code)
    {
        const string route = "/verifycodeemail";
        var response = await HttpProvider.Get<object>(BaseRoute + route,(nameof(numberRegistratrtion), numberRegistratrtion.ToString()), (nameof(code), code));
        return response;
    }
}
