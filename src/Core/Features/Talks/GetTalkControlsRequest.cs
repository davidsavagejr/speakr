using MediatR;
using Models;

namespace Core.Features.Talks
{
    public class GetTalkControlsRequest : IRequest<Talk>
    {
        public GetTalkControlsRequest(long? id)
        {
            Id = id;
        }

        public long? Id { get; set; }
    }
}