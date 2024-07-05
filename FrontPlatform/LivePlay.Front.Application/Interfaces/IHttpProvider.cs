
using LivePlay.Front.Application.Contracts.Responses;

namespace LivePlay.Front.Application.Interfaces;

public interface IHttpProvider
{
    public Task<BaseResponse> Get(string route, params (string, string)[] requestParams);
    public Task<BaseResponse> Post<R>(string route, R jsonRequest, params (string, string)[] requestParams);
    public Task<BaseResponse> Put<R>(string route, R jsonRequest, params (string, string)[] requestParams);
    public Task<BaseResponse> Delete(string route, params (string, string)[] requestParams);
}
