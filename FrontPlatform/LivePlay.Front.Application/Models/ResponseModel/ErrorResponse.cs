
namespace LivePlay.Front.Application.Models.ResponseModel;

internal class ErrorResponse
{
    public required string ErrorCode { get; set; }
    public required string Message { get; set; }
    public required string Details { get; set; }
}
