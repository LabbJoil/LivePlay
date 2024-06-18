
using AutoMapper;
using LivePlay.Server.Core.Models;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.Application.Mapping;

public class UserUserEntityMapping : Profile
{
    public UserUserEntityMapping()
    {
        CreateMap<User, UserEntityModel>().ReverseMap()
            .ForMember(u => u.Password, opt => opt.MapFrom(uem => uem.PasswordHash));

        CreateMap<UserEntityModel, User>().ReverseMap()
            .ForMember(u => u.PasswordHash, opt => opt.MapFrom(uem => uem.Password));
    }
}
