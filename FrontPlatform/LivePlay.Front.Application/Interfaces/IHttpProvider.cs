
using LivePlay.Front.Application.Contracts.ResponseModel;

namespace LivePlay.Front.Application.Interfaces;

public interface IHttpProvider
{
    public Task<BaseResponse<T>> Get<T>(string route, params (string, string)[] requestParams);
    public Task<BaseResponse<T>> Post<T, R>(string route, R jsonRequest, params (string, string)[] requestParams);
    public Task<BaseResponse<T>> Put<T, R>(string route, R jsonRequest, params (string, string)[] requestParams);
    public Task<BaseResponse<T>> Delete<T>(string route, params (string, string)[] requestParams);
}
