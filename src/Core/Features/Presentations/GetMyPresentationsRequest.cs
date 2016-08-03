using System.Collections.Generic;
using MediatR;
using Data.Models;

namespace Core.Features.Presentations
{
    public class GetMyPresentationsRequest : IRequest<List<Presentation>> { }
}