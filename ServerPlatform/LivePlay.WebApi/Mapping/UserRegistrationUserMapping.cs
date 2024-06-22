﻿
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests;

namespace LivePlay.Server.WebApi.Mapping;

public class UserRegistrationUserMapping : Profile
{
    public UserRegistrationUserMapping()
    {
        CreateMap<RegistrationUserRequest, User>();
    }
}
