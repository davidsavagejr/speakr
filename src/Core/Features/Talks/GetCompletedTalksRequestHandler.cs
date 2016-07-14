using System.Collections.Generic;
using Core.Security;
using MediatR;
using Models;
using NPoco;

namespace Core.Features.Talks
{
    public class GetCompletedTalksRequestHandler : IRequestHandler<GetCompletedTalksRequest, IEnumerable<Talk>>
    {
        private readonly IDatabase _database;
        private readonly IUser _currentUser;

        public GetCompletedTalksRequestHandler(IDatabase database, IUser currentUser)
        {
            _database = database;
            _currentUser = currentUser;
        }

        public IEnumerable<Talk> Handle(GetCompletedTalksRequest message)
        {
            return _database.Fetch<Talk>(@"SELECT TOP 20 t.* 
                                                FROM Talk t
                                                INNER JOIN Presentation p ON p.Id = t.PresentationId 
                                                    AND t.IsStarted = 1 
                                                    AND t.EndDate IS NOT NULL 
                                           WHERE p.[User] LIKE @0", _currentUser.KeyForRecords);
        }
    }
}