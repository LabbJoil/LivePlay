
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.WebApi.Contracts.Requests.User;

namespace LivePlay.Server.WebApi.Mappings.UserMappings;

public class UserRegistrationMapping : Profile
{
    public UserRegistrationMapping()
    {
        CreateMap<RegistrationUserRequest, User>();
    }
}
