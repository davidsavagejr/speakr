using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Features.Presentations;
using Data.Core.Models;
using Web.Core.Models;
using Presentation = Data.Core.Models.Presentation;

namespace Web.Core
{
    public class WebMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Presentation, CreatePresentationRequest>();
            CreateMap<DeletePresentation, DeletePresentationRequest>();
            CreateMap<IEnumerable<FeedbackForTalk>, FeedbackView>()
                .ForMember(m => m.Title, o => o.Condition(c => c != null))
                .ForMember(m => m.Title, o => o.MapFrom(src => src.FirstOrDefault().Title))
                .ForMember(m => m.StartDate, o => o.Condition(c => c != null))
                .ForMember(m => m.StartDate, o => o.MapFrom(src => src.FirstOrDefault().StartDate))
                .ForMember(m => m.EndDate, o => o.Condition(c => c != null))
                .ForMember(m => m.EndDate, o => o.MapFrom(src => src.FirstOrDefault().EndDate))
                .ForMember(m => m.Entries, o => o.MapFrom(src => src.ToList()));
            CreateMap<FeedbackForTalk, FeedbackEntry>();
        }
    }
}