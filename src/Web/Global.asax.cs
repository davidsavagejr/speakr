using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;
using Web.App_Start;
using Web.DependencyResolution;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, IoC.Initialize());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
