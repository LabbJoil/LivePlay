namespace LivePlay.Server.WebApi.Contracts;

public class ErrorResponse
{
    public required string ErrorCode { get; set; }
    public required string Message { get; set; }
}
