using System.Collections.Generic;
using Core.Security;
using MediatR;
using NPoco;

namespace Core.Features.Presentations
{
    public class GetMyPresentationsRequestHandler : IRequestHandler<GetMyPresentationsRequest, List<global::Models.Presentation>>
    {
        private readonly IDatabase _database;
        private readonly IUser _user;

        public GetMyPresentationsRequestHandler(IDatabase database, IUser user)
        {
            _database = database;
            _user = user;
        }

        public List<global::Models.Presentation> Handle(GetMyPresentationsRequest message)
        {
            var presentations = _database.Fetch<global::Models.Presentation>("WHERE [User] LIKE @0", _user.NameIdentifier) ??
                                new List<global::Models.Presentation>();

            return presentations;
        }
    }
}