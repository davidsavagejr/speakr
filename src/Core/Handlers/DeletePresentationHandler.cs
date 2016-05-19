using System.Linq;
using Core.Requests;
using MediatR;
using Models;
using NPoco;

namespace Core.Handlers
{
    public class DeletePresentationHandler : RequestHandler<DeletePresentationRequest>
    {
        private readonly IDatabase _database;

        public DeletePresentationHandler(IDatabase database)
        {
            _database = database;
        }

        protected override void HandleCore(DeletePresentationRequest message)
        {
            _database.BeginTransaction();

            var presentation = _database.SingleOrDefault<Presentation>("WHERE id = @0 AND [User] LIKE @1", message.Id, message.UserId);
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