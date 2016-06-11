using Core.Models;
using Core.Security;
using MediatR;
using NPoco;

namespace Core.Features.Users
{
    public class GetUserDataRequestHandler : IRequestHandler<GetUserDataRequest, UserData>
    {
        private readonly IDatabase _database;
        private readonly IUser _user;

        public GetUserDataRequestHandler(IDatabase database, IUser user)
        {
            _database = database;
            _user = user;
        }

        public UserData Handle(GetUserDataRequest message)
        {
            var data = new UserData();

            data.PresentationCount =
                _database.SingleOrDefault<int>("SELECT COUNT(*) FROM Presentation WHERE [User] LIKE @0", _user.NameIdentifier);

            data.FeedbackCount =
                _database.SingleOrDefault<int>(@"SELECT COUNT(*) FROM Feedback f
                                                INNER JOIN Talk t on t.Id = f.TalkId
                                                INNER JOIN Presentation p on p.Id = t.PresentationId
                                                WHERE p.[User] LIKE @0", _user.NameIdentifier);

            return data;
        }
    }
}