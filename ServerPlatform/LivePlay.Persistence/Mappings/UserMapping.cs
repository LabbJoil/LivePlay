
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Persistence.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserEntityModel, User>()
            .ForMember(u => u.Password, opt => opt.MapFrom(uem => uem.PasswordHash))
            .ReverseMap()
            .ForMember(u => u.PasswordHash, opt => opt.MapFrom(uem => uem.Password))
            .ForMember(u => u.Points, opt => opt.Ignore())
            .ForMember(u => u.Roles, opt => opt.Ignore());
    }
}
