
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests;

namespace LivePlay.Server.WebApi.Mapping;

public class UserUpdateUserMapping : Profile
{
    public UserUpdateUserMapping()
    {
        CreateMap<LoginUserRequest, User>();
    }
}
