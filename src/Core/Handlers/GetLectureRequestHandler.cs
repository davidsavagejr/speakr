using Core.Requests;
using MediatR;
using Models;
using NPoco;

namespace Core.Handlers
{
    public class GetLectureRequestHandler : IRequestHandler<GetTalkRequest, Talk>
    {
        private readonly IDatabase _database;

        public GetLectureRequestHandler(IDatabase database)
        {
            _database = database;
        }

        public Talk Handle(GetTalkRequest message)
        {
            return _database.FirstOrDefault<Talk>("WHERE Code LIKE @0", message.Code);
        }
    }
}