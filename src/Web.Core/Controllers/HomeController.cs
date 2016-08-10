using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}