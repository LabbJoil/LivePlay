
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Application.Mapping;

public class UserEntityMapping : Profile
{
    public UserEntityMapping()
    {
        CreateMap<UserEntityModel, User>()
            .ForMember(u => u.Password, opt => opt.MapFrom(uem => uem.PasswordHash))
            .ReverseMap()
            .ForMember(u => u.PasswordHash, opt => opt.MapFrom(uem => uem.Password));
    }
}
