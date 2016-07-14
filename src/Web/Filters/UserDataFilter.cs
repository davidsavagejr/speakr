using System.Web.Mvc;
using Core.Features.Users;
using MediatR;

namespace Web.Filters
{
    public class UserDataFilter : ActionFilterAttribute
    {
        private readonly IMediator _mediator;

        public UserDataFilter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if(!filterContext.HttpContext.User.Identity.IsAuthenticated)
                return;

            // Cache this later
            var data = _mediator.Send(new GetUserDataRequest());
            if (data == null)
                return;

            filterContext.Controller.ViewBag.UserPresentationCount = data.PresentationCount;
            filterContext.Controller.ViewBag.FeedbackCount = data.FeedbackCount;
        }
    }
}