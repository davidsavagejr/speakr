using AutoMapper;
using Core.Features.Presentations;
using Web.Models;

namespace Web
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Presentation, CreatePresentationRequest>();
            CreateMap<DeletePresentation, DeletePresentationRequest>();
        }
    }
}