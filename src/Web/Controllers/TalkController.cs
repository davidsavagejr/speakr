using System.Web.Mvc;
using Core.Requests;
using MediatR;
using Web.Models;

namespace Web.Controllers
{
    public class TalkController : Controller
    {
        private readonly IMediator _mediator;

        public TalkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Create(PresentationCreated presentationid)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Index(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length != 6)
                return RedirectToAction("Index", "Home");

            var talk = _mediator.Send(new GetTalkRequest(code));

            if(talk == null)
                return RedirectToAction("Index", "Home");

            return View(talk);
        }
    }
}