using System.Collections.Generic;
using Data.Core.Models;
using MediatR;

namespace Core.Features.Presentations
{
    public class GetMyPresentationsRequest : IRequest<List<Presentation>> { }
}