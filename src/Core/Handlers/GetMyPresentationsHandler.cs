using System.Collections.Generic;
using Core.Requests;
using MediatR;
using Models;
using NPoco;

namespace Core.Handlers
{
    public class GetMyPresentationsHandler : IRequestHandler<GetMyPresentationsRequest, List<Presentation>>
    {
        private readonly IDatabase _database;

        public GetMyPresentationsHandler(IDatabase database)
        {
            _database = database;
        }

        public List<Presentation> Handle(GetMyPresentationsRequest message)
        {
            var presentations = _database.Fetch<Presentation>("WHERE [User] LIKE @0", message.User) ??
                                new List<Presentation>();

            return presentations;
        }
    }
}