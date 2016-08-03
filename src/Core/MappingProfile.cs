using AutoMapper;
using Core.Features.Presentations;
using Data.Models;

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