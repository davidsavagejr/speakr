using MediatR;

namespace Core.Requests
{
    public class DeletePresentationRequest : IRequest
    {
        public int Id { get; set; }

        public string UserId { get; set; }
    }
}