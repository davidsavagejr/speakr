using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StackExchange.Profiling;
using Web.DependencyResolution;

namespace Web
{
    public class App : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, IoC.Initialize());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        internal static IPrincipal DebugUser { get; set; }
        
        protected void Application_AuthenticateRequest()
        {
            if (!Config.Settings.UserDebug)
                return;

            HttpContext.Current.User = DebugUser;
            Thread.CurrentPrincipal = DebugUser;
        }

        protected void Application_BeginRequest()
        {
            if (Config.Settings.MiniProfiler)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            if (Config.Settings.MiniProfiler)
            {
                MiniProfiler.Stop();
            }
        }
    }
}
