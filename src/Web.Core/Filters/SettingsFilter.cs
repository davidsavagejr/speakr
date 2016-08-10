using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Web.Core.Config;

namespace Web.Core.Filters
{
    public class SettingsFilter : ActionFilterAttribute
    {
        private readonly IOptions<AppSettings> _appSettings;

        public SettingsFilter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var controller = context.Controller as Controller;
            if (controller == null) return;
            controller.ViewBag.Settings = _appSettings.Value;
        }
    }
}