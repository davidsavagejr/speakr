using System.Collections.Generic;
using Data.Models;
using MediatR;

namespace Core.Features.Feedback
{
    public class GetMyFeedbackRequest : IRequest<IEnumerable<MyFeedback>>
    {
         
    }
}