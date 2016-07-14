using System.Linq;
using Core.Security;
using MediatR;
using Models;
using NPoco;

namespace Core.Features.Presentations
{
    public class DeletePresentationRequestHandler : RequestHandler<DeletePresentationRequest>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public DeletePresentationRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        protected override void HandleCore(DeletePresentationRequest message)
        {
            _database.BeginTransaction();

            var presentation = _database.SingleOrDefault<Presentation>("WHERE id = @0 AND [User] LIKE @1", message.Id, _currentUser.KeyForRecords);
            if (presentation == null)
                return;

            var talks = _database.Fetch<long>("SELECT Id FROM Talk WHERE PresentationId = @0", message.Id);
            if (talks.Any())
            {
                _database.Execute("DELETE FROM Feedback WHERE TalkId IN(@0)", talks);
            }

            _database.Execute("DELETE FROM Talk WHERE Id IN(@0)", talks);
            _database.Delete(presentation);
            _database.CompleteTransaction();
        }
    }
}