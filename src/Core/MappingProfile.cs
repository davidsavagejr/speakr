using AutoMapper;
using Core.Features.Presentations;
using Models;

namespace Core
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreatePresentationRequest, Presentation>();

        }
    }
}