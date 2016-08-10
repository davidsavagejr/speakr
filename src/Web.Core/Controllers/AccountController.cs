using Microsoft.AspNetCore.Mvc;

namespace Web.Core.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignIn()
        {
            if (Config.Settings.UserDebug)
                Program.DebugUser = new TestPrincipal();
            return Redirect("/");
        }

        public ActionResult SignOut()
        {
            if (Config.Settings.UserDebug)
                Program.DebugUser = null;
            return Redirect("/");
        }
    }
}
