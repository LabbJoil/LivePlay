
using LivePlay.Front.Application.Contracts.ResponseModel;
using LivePlay.Front.Application.Interfaces;
using LivePlay.Front.Application.Models.ResponseModel;

namespace LivePlay.Front.MAUI.Services.HttpServices;

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
}
