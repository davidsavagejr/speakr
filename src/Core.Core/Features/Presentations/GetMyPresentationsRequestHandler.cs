using System.Collections.Generic;
using Core.Security;
using Data.Core.Models;
using MediatR;
using NPoco;

namespace Core.Features.Presentations
{
    public class GetMyPresentationsRequestHandler : IRequestHandler<GetMyPresentationsRequest, List<Presentation>>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public GetMyPresentationsRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        public List<Presentation> Handle(GetMyPresentationsRequest message)
        {
            var presentations = _database.Fetch<Presentation>("WHERE [User] LIKE @0", _currentUser.KeyForRecords) ??
                                new List<Presentation>();

            return presentations;
        }
    }
}