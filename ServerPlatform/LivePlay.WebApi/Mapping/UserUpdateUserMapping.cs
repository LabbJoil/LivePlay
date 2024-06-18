
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts;

namespace LivePlay.Server.WebApi.Mapping;

public class UserUpdateUserMapping : Profile
{
    public UserUpdateUserMapping()
    {
        CreateMap<LoginUserRequest, User>();
    }
}
