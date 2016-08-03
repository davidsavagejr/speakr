using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using Core.Features.Feedback;
using Core.Features.Presentations;
using MediatR;
using Web.Filters;
using Web.Models;

namespace Web.Controllers
{
    public class MyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        public ActionResult Presentations()
        {
            var presentations = _mediator.Send(new GetMyPresentationsRequest());

            if (!presentations.Any())
                return RedirectToAction("Create", "Presentation");

            return View(presentations);
        }

        [Authorize]
        public ActionResult Feedback(long? id = null)
        {
            if (!id.HasValue)
            {
                var completedTalks = _mediator.Send(new GetMyFeedbackRequest());
                return View(completedTalks);
            }

            var feedback = _mediator.Send(new GetFeedbackForTalkRequest(id.Value));
            var model = _mapper.Map<FeedbackView>(feedback);
            return View("FeedbackDetails", model);
        }

        [Authorize, LocalOnly]
        public ActionResult Claims()
        {
            var claims = (User.Identity as ClaimsIdentity)?.Claims;
            return View(claims);
        }

        
    }
}