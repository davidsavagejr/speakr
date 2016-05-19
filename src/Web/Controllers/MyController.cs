using System.Linq;
using System.Web.Mvc;
using Core.Requests;
using MediatR;

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
            var presentations = _mediator.Send(new GetMyPresentationsRequest(User.Identity.Name));

            if (!presentations.Any())
                return RedirectToAction("Create", "Presentation");

            return View(presentations);
        }
    }
}