using System.Web.Mvc;

namespace Web.Filters
{
    /// <summary>
    /// Specifies that access to the action or controller is restricted to when the app is run locally
    /// </summary>
    public class LocalOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsLocal)
                return;

            filterContext.Result = new RedirectResult("/");
        }
    }
}