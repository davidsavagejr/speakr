using System;
using System.Linq;
using Core.Features.Codes;
using Core.Security;
using Data.Core.Models;
using MediatR;
using NPoco;

namespace Core.Features.Talks
{
    public class CreateTalkRequestHandler : IRequestHandler<CreateTalkRequest, long?>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;
        private readonly ICodeGenerator _codeGenerator;

        public CreateTalkRequestHandler(IDatabase database, IUser currentUser, ICodeGenerator codeGenerator)
        {
            _database = database;
            _currentUser = currentUser;
            _codeGenerator = codeGenerator;
        }

        public long? Handle(CreateTalkRequest message)
        {
            var presentation = _database.FirstOrDefault<Presentation>("WHERE [User] LIKE @0 AND Id = @1", _currentUser.KeyForRecords, message.PresentationId);
            if (presentation == null)
                return null;

            // Don't start a new presentation all the time
            var unstartedTalk = _database.Fetch<Talk>("WHERE PresentationId = @0 AND IsStarted = 0", presentation.Id);
            if (unstartedTalk != null && unstartedTalk.Any())
                return unstartedTalk.First().Id;

            var talk = new Talk
            {
                PresentationId = presentation.Id,
                Code = _codeGenerator.Generate(5),
                Title = presentation.Name,
                StartDate = DateTime.UtcNow
            };

            _database.Insert(talk);

            return talk.Id;
        }
    }
}