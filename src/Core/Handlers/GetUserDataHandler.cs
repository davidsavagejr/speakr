using Core.Models;
using Core.Requests;
using MediatR;
using NPoco;

namespace Core.Handlers
{
    public class GetUserDataHandler : IRequestHandler<GetUserDataRequest, UserData>
    {
        private readonly IDatabase _database;

        public GetUserDataHandler(IDatabase database)
        {
            _database = database;
        }

        public UserData Handle(GetUserDataRequest message)
        {
            var data = new UserData();

            data.PresentationCount =
                _database.SingleOrDefault<int>("SELECT COUNT(*) FROM Presentation WHERE [User] LIKE @0", message.UserId);

            data.FeedbackCount =
                _database.SingleOrDefault<int>(@"SELECT COUNT(*) FROM Feedback f
                                                INNER JOIN Talk t on t.Id = f.TalkId
                                                INNER JOIN Presentation p on p.Id = t.PresentationId
                                                WHERE p.[User] LIKE @0", message.UserId);

            return data;
        }
    }
}