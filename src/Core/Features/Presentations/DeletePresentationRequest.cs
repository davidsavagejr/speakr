using MediatR;

namespace Core.Features.Presentations
{
    public class DeletePresentationRequest : IRequest
    {
        public int Id { get; set; }
    }
}