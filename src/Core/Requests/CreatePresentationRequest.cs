using MediatR;

namespace Core.Requests
{
    public class CreatePresentationRequest : IRequest<long>
    {
        public string Name { get; set; } 

        public string UserId { get; set; }

        public string Description { get; set; }
    }
}