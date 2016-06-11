using MediatR;
using NPoco;

namespace Core.Features.Talks
{
    public class GetTalkRequestHandler : IRequestHandler<GetTalkRequest, global::Models.Talk>
    {
        private readonly IDatabase _database;

        public GetTalkRequestHandler(IDatabase database)
        {
            _database = database;
        }

        public global::Models.Talk Handle(GetTalkRequest message)
        {
            return _database.FirstOrDefault<global::Models.Talk>("WHERE Code LIKE @0", message.Code);
        }
    }
}