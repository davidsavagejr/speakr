using MediatR;

namespace Core.Features.Presentations
{
    public class CreatePresentationRequest : IRequest<long>
    {
        public string Name { get; set; } 

        public string Description { get; set; }
    }
}