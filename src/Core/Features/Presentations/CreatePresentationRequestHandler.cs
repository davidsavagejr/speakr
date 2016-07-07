using System;
using Core.Security;
using MediatR;
using NPoco;

namespace Core.Features.Presentations
{
    public class CreatePresentationRequestHandler : IRequestHandler<CreatePresentationRequest, long>
    {
        private readonly IDatabase _database;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IUser _user;

        public CreatePresentationRequestHandler(IDatabase database, AutoMapper.IMapper mapper, IUser user)
        {
            _database = database;
            _mapper = mapper;
            _user = user;
        }

        public long Handle(CreatePresentationRequest message)
        {
            if (_user == null)
                throw new UnauthorizedAccessException("Cannot create presentation without an authenticated user");

            var presentation = _mapper.Map<global::Models.Presentation>(message);
            presentation.User = _user.KeyForRecords;
            presentation.DateCreated = DateTime.UtcNow;

            _database.Insert(presentation);
;
            return presentation.Id;
        }
    }
}