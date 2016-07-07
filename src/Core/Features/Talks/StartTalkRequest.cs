using MediatR;

namespace Core.Features.Talks
{
    public class StartTalkRequest : IRequest
    {
        public StartTalkRequest(long? id)
        {
            Id = id;
        }

        public long? Id { get; set; } 
    }
}