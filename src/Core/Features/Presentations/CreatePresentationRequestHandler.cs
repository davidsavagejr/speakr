using System;
using Core.Security;
using MediatR;
using Data.Models;
using NPoco;

namespace Core.Features.Presentations
{
    public class CreatePresentationRequestHandler : IRequestHandler<CreatePresentationRequest, long>
    {
        private readonly IDatabase _database;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IUser _currentUser;

        public CreatePresentationRequestHandler(IDatabase database, AutoMapper.IMapper mapper, IUser currentUser)
        {
            _database = database;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public long Handle(CreatePresentationRequest message)
        {
            var presentation = _mapper.Map<Presentation>(message);
            presentation.User = _currentUser.KeyForRecords;
            presentation.DateCreated = DateTime.UtcNow;

            _database.Insert(presentation);
;
            return presentation.Id;
        }
    }
}