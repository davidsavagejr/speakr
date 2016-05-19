using System.Collections.Generic;
using MediatR;
using Models;

namespace Core.Requests
{
    public class GetMyPresentationsRequest : IRequest<List<Presentation>>
    {
        public GetMyPresentationsRequest(string user)
        {
            User = user;
        }

        public string User { get; set; }
    }
}