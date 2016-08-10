using AutoMapper;
using Core.Features.Presentations;
using Data.Core.Models;

namespace Core.Core
{
    public class CoreMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreatePresentationRequest, Presentation>();

        }
    }
}