
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.User;

namespace LivePlay.Server.WebApi.Mapping.User;

public class UserUpdateMapping : Profile
{
    public UserUpdateMapping()
    {
        CreateMap<LoginUserRequest, User>();
    }
}
