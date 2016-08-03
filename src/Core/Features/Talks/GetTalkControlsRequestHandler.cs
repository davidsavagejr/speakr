using Core.Security;
using Data.Models;
using MediatR;
using NPoco;

namespace Core.Features.Talks
{
    public class GetTalkControlsRequestHandler : IRequestHandler<GetTalkControlsRequest, Talk>
    {
        private readonly IUser _currentUser;
        private readonly IDatabase _database;

        public GetTalkControlsRequestHandler(IUser currentUser, IDatabase database)
        {
            _currentUser = currentUser;
            _database = database;
        }

        public Talk Handle(GetTalkControlsRequest message)
        {
            return _database.FirstOrDefault<Talk>(CommonSql.Talks.GetTalkForOwner, _currentUser.KeyForRecords, message.Id);
        }
    }
}