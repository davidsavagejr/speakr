using System;
using Core.Security;
using MediatR;
using Models;
using NPoco;

namespace Core.Features.Talks
{
    public class StartTalkRequestHandler : RequestHandler<StartTalkRequest>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public StartTalkRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        protected override void HandleCore(StartTalkRequest message)
        {
            var talk = _database.SingleOrDefault<Talk>(CommonSql.Talks.GetTalkForOwner, _currentUser.KeyForRecords, message.Id);
            if (talk == null)
                return;

            talk.IsStarted = true;
            talk.StartDate = DateTime.UtcNow;

            _database.Update(talk);
        }
    }
}