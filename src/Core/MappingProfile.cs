using AutoMapper;
using Core.Requests;
using Models;

namespace Core
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreatePresentationRequest, Presentation>()
                .ForMember(m => m.User, m => m.MapFrom(src => src.UserId));
        }
    }
}