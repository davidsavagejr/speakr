using MediatR;

namespace Core.Requests
{
    public class GetPresentationRequest : IRequest<Models.Presentation>
    {
        public double Id { get; set; }
    }
}