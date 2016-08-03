using System.Collections.Generic;
using Core.Security;
using Data.Models;
using MediatR;
using NPoco;

namespace Core.Features.Feedback
{
    public class GetFeedbackForTalkRequestHandler : IRequestHandler<GetFeedbackForTalkRequest, IEnumerable<FeedbackForTalk>>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public GetFeedbackForTalkRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        public IEnumerable<FeedbackForTalk> Handle(GetFeedbackForTalkRequest message)
        {
            return _database.Fetch<FeedbackForTalk>(@"SELECT 
	                                                        f.Summary,
	                                                        f.Comments,
	                                                        f.EntryDate,
	                                                        f.Id,
	                                                        t.Title,
	                                                        t.StartDate,
	                                                        t.EndDate
                                                        FROM	Feedback f
                                                        JOIN	Talk t on t.Id = f.TalkId
                                                        JOIN	Presentation p ON p.Id = t.PresentationId
                                                        WHERE   p.[User] LIKE @0
                                                        AND     f.TalkId = @1", 
                                                        _currentUser.KeyForRecords,
                                                        message.TalkId);
        }
    }
}