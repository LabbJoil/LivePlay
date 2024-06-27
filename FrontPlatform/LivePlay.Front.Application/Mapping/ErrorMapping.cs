
using AutoMapper;
using LivePlay.Front.Application.Models.ResponseModel;
using LivePlay.Front.Core.Models;

namespace LivePlay.Front.Application.Mapping;

public class ErrorMapping : Profile
{
    public ErrorMapping()
    {
        CreateMap<ErrorResponse, ErrorModel>()
            .ForMember(em => em.Title, opt => opt.MapFrom(er => er.ErrorCode))
            .ForMember(em => em.Message, opt => opt.MapFrom(er => er.Message));
    }
}
