using LivePlay.Front.Application.Contracts.ResponseModel;
using LivePlay.Front.Application.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePlay.Front.Application.Interfaces;

public interface IHttpProvider
{
    public Task<BaseResponse<T>> Get<T>(string route, params (string, string)[] requestParams);
    public Task<BaseResponse<T>> Post<T, R>(string route, R jsonRequest, params (string, string)[] requestParams);
    public Task<BaseResponse<T>> Put<T, R>(string route, R jsonRequest, params (string, string)[] requestParams);
    public Task<BaseResponse<T>> Delete<T>(string route, params (string, string)[] requestParams);
}
