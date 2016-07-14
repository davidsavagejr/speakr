using System.Collections.Generic;
using MediatR;
using Models;

namespace Core.Features.Talks
{
    public class GetCompletedTalksRequest : IRequest<IEnumerable<Talk>>
    {
         
    }
}