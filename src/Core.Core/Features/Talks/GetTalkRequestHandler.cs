using Data.Core.Models;
using MediatR;
using NPoco;

namespace Core.Features.Talks
{
    public class GetTalkRequestHandler : IRequestHandler<GetTalkRequest, Talk>
    {
        private readonly IDatabase _database;

        public GetTalkRequestHandler(IDatabase database)
        {
            _database = database;
        }

        public Talk Handle(GetTalkRequest message)
        {
            return _database.FirstOrDefault<Talk>("WHERE Code LIKE @0", message.Code);
        }
    }
}