
using LivePlay.Front.Application.Models.ResponseModel;

namespace LivePlay.Front.Application.Contracts.Responses;

public class BaseResponse
{
    public bool IsSuccess { get; set; } = true;
    public string ResponseData { get; set; } = string.Empty;
    public string? Error { get; set; }

    public BaseResponse() { }

    public BaseResponse(string body)
    {
        ResponseData = body;
    }
}
