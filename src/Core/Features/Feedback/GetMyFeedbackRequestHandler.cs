using System.Collections.Generic;
using Core.Security;
using Data.Models;
using MediatR;
using NPoco;

namespace Core.Features.Feedback
{
    public class GetMyFeedbackRequestHandler : IRequestHandler<GetMyFeedbackRequest, IEnumerable<MyFeedback>>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public GetMyFeedbackRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        public IEnumerable<MyFeedback> Handle(GetMyFeedbackRequest message)
        {
            return _database.Fetch<MyFeedback>(@"SELECT 
	                                        t.Id,
	                                        t.Title,
	                                        t.StartDate,
	                                        t.EndDate,
	                                        p.Name,
	                                        p.Description,
	                                        (SELECT COUNT(*) FROM Feedback f WHERE f.TalkId = t.Id) as FeedbackCount
                                        FROM	Talk t
                                        JOIN	Presentation p ON p.Id = t.PresentationId
                                        WHERE p.[User] LIKE @0", _currentUser.KeyForRecords);
        }
    }
}