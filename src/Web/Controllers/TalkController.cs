using System.Web.Mvc;
using Core.Features.Talks;
using MediatR;

namespace Web.Controllers
{
    public class TalkController : Controller
    {
        private readonly IMediator _mediator;

        public TalkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        public ActionResult Create(long? presentationid)
        {
            if(!presentationid.HasValue)
                return RedirectToAction("Presentations", "My");

            var talkId = _mediator.Send(new CreateTalkRequest(presentationid.Value));
            if(!talkId.HasValue)
                return RedirectToAction("Presentations", "My");

            return RedirectToAction("Controls", new {id = talkId});

        }

        public ActionResult Index(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length != 5)
                return RedirectToAction("Index", "Home");

            var talk = _mediator.Send(new GetTalkRequest(code));

            if(talk == null)
                return RedirectToAction("Index", "Home");

            return View(talk);
        }

        [Authorize]
        public ActionResult Controls(long? id)
        {
            var talk = _mediator.Send(new GetTalkControlsRequest(id));
            if (talk == null)
                return RedirectToAction("Index", "Home");

            return View(talk);
        }

        [Authorize]
        public ActionResult Start(long? id)
        {
            var talk = _mediator.Send(new GetTalkControlsRequest(id));
            if (talk == null)
                return RedirectToAction("Index", "Home");

            _mediator.Send(new StartTalkRequest(id));

            if(talk.EndDate.HasValue)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Controls", new { id });
        }

        [Authorize]
        public ActionResult Complete(long? id)
        {
            var talk = _mediator.Send(new GetTalkControlsRequest(id));
            if (talk == null)
                return RedirectToAction("Index", "Home");

            _mediator.Send(new CompleteTalkRequest(id));

            return RedirectToAction("Index", "Home");
        }
    }
}