using System.Collections.Generic;
using Core.Security;
using MediatR;
using Models;
using NPoco;

namespace Core.Features.Presentations
{
    public class GetMyPresentationsRequestHandler : IRequestHandler<GetMyPresentationsRequest, List<Presentation>>
    {
        private readonly IDatabase _database;
        private readonly IUser _user;

        public GetMyPresentationsRequestHandler(IDatabase database, IUser user)
        {
            _database = database;
            _user = user;
        }

        public List<Presentation> Handle(GetMyPresentationsRequest message)
        {
            var presentations = _database.Fetch<Presentation>("WHERE [User] LIKE @0", _user.KeyForRecords) ??
                                new List<Presentation>();

            return presentations;
        }
    }
}