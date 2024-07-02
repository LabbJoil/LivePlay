
using LivePlay.Front.Application.Models.ResponseModel;

namespace LivePlay.Front.Application.Contracts.Responses;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; } = true;
    public T? Data { get; set; }
    public ErrorResponse? Error { get; set; }
}
