using System;
using Core.Requests;
using MediatR;
using Models;
using NPoco;

namespace Core.Handlers
{
    public class CreatePresentationHandler : IRequestHandler<CreatePresentationRequest, long>
    {
        private readonly IDatabase _database;
        private readonly AutoMapper.IMapper _mapper;

        public CreatePresentationHandler(IDatabase database, AutoMapper.IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public long Handle(CreatePresentationRequest message)
        {
            var presentation = _mapper.Map<Presentation>(message);
            presentation.DateCreated = DateTime.UtcNow;

            _database.Insert(presentation);
;
            return presentation.Id;
        }
    }
}