using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn()
        {
            if (Config.Settings.UserDebug)
                App.DebugUser = new TestPrincipal();
            return Redirect("/");
        }

        public ActionResult SignOut()
        {
            if (Config.Settings.UserDebug)
                App.DebugUser = null;
            return Redirect("/");
        }
    }
}
