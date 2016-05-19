using System.Web.Mvc;
using MediatR;
using StructureMap;
using Web.Filters;

namespace Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IContainer container)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UserDataFilter(container.GetInstance<IMediator>()));
        }
    }
}
