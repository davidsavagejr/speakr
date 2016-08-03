using System.Collections.Generic;
using Data.Models;
using MediatR;

namespace Core.Features.Feedback
{
    public class GetFeedbackForTalkRequest : IRequest<IEnumerable<FeedbackForTalk>>
    {
        public GetFeedbackForTalkRequest(long talkId)
        {
            TalkId = talkId;
        }

        public long TalkId { get; set; }
    }
}