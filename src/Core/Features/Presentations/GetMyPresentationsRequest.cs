using System.Collections.Generic;
using MediatR;
using Models;

namespace Core.Features.Presentations
{
    public class GetMyPresentationsRequest : IRequest<List<Presentation>> { }
}