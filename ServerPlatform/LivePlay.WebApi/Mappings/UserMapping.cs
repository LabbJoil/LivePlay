
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.User;

namespace LivePlay.Server.WebApi.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<RegistrationUserRequest, User>();
        CreateMap<LoginUserRequest, User>();
    }
}
