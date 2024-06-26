﻿
using LivePlay.Server.Core.Enums;

namespace LivePlay.Server.WebApi.Contracts.Responses;

public class ErrorResponse
{
    public required ErrorCode ErrorCode { get; set; }
    public required string Message { get; set; }
}
