using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Core.Features.Presentations;
using MediatR;
using Web.Filters;

namespace Web.Controllers
{
    public class MyController : Controller
    {
        private readonly IMediator _mediator;

        public MyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        public ActionResult Presentations()
        {
            var presentations = _mediator.Send(new GetMyPresentationsRequest());

            if (!presentations.Any())
                return RedirectToAction("Create", "Presentation");

            return View(presentations);
        }

        [Authorize, LocalOnly]
        public ActionResult Claims()
        {
            var claims = (User.Identity as ClaimsIdentity)?.Claims;
            return View(claims);
        }
    }
}