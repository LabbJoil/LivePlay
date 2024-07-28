
using AutoMapper;
using LivePlay.Front.Core.Models;
using LivePlay.Front.Infrastructure.Contracts.Requests.UserRequests;

namespace LivePlay.Front.Infrastructure.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, RegistrationUserRequest>();
        CreateMap<User, LoginUserRequest>();
    }
}
