using System;
using Core.Security;
using MediatR;
using Data.Models;
using NPoco;

namespace Core.Features.Talks
{
    public class CompleteTalkRequestHandler : RequestHandler<CompleteTalkRequest>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public CompleteTalkRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        protected override void HandleCore(CompleteTalkRequest message)
        {
            var talk = _database.SingleOrDefault<Talk>(CommonSql.Talks.GetTalkForOwner, _currentUser.KeyForRecords, message.Id);
            if (talk == null)
                return;

            talk.EndDate = DateTime.UtcNow;
            _database.Update(talk);
        }
    }
}