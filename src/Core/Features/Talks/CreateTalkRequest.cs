using MediatR;

namespace Core.Features.Talks
{
    public class CreateTalkRequest : IRequest<long?>
    {
        public CreateTalkRequest() { }

        public CreateTalkRequest(long presentationId)
        {
            PresentationId = presentationId;
        }

        public long PresentationId { get; set; }
    }
}