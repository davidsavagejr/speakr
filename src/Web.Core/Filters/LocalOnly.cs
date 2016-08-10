using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.Core.Extensions;

namespace Web.Core.Filters
{
    /// <summary>
    /// Specifies that access to the action or controller is restricted to when the app is run locally
    /// </summary>
    public class LocalOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.IsLocal())
                return;

            context.Result = new RedirectResult("/");
        }
    }
}