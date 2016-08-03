using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Features.Presentations;
using Data.Models;
using Web.Models;
using Presentation = Data.Models.Presentation;

namespace Web
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Presentation, CreatePresentationRequest>();
            CreateMap<DeletePresentation, DeletePresentationRequest>();
            CreateMap<IEnumerable<FeedbackForTalk>, FeedbackView>()
                .ForMember(m => m.Title, o => o.Condition(c => !c.IsSourceValueNull))
                .ForMember(m => m.Title, o => o.MapFrom(src => src.FirstOrDefault().Title))
                .ForMember(m => m.StartDate, o => o.Condition(c => !c.IsSourceValueNull))
                .ForMember(m => m.StartDate, o => o.MapFrom(src => src.FirstOrDefault().StartDate))
                .ForMember(m => m.EndDate, o => o.Condition(c => !c.IsSourceValueNull))
                .ForMember(m => m.EndDate, o => o.MapFrom(src => src.FirstOrDefault().EndDate))
                .ForMember(m => m.Entries, o => o.MapFrom(src => src.ToList()));
            CreateMap<FeedbackForTalk, FeedbackEntry>();
        }
    }
}