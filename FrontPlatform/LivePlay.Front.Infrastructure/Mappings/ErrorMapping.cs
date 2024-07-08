
using AutoMapper;
using LivePlay.Front.Infrastructure.Models.ResponseModel;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.Infrastructure.Mappings;

public class ErrorMapping : Profile
{
    public ErrorMapping()
    {
        CreateMap<ErrorResponse, DisplayError>()
            .ForMember(em => em.Title, opt => opt.MapFrom(er => er.ErrorCode))
            .ForMember(em => em.Message, opt => opt.MapFrom(er => er.Message));
    }
}
