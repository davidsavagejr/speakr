using MediatR;

namespace Core.Features.Talks
{
    public class CompleteTalkRequest : IRequest
    {
        public long? Id { get; set; }

        public CompleteTalkRequest(long? id)
        {
            Id = id;
        }
    }
}