using Core.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class UserDataFilter : IResultFilter
    {
        private readonly IMediator _mediator;

        public UserDataFilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                return;

            // Cache this later
            var data = _mediator.Send(new GetUserDataRequest());
            if (data == null)
                return;

            var controller = context.Controller as Controller;
            if (controller == null) return;
            controller.ViewBag.UserPresentationCount = data.PresentationCount;
            controller.ViewBag.FeedbackCount = data.FeedbackCount;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }
    }
}