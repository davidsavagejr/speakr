using AutoMapper;
using Core.Features.Presentations;
using Core.Features.Talks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Core.Models;

namespace Web.Core.Controllers
{
    public class PresentationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PresentationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public ActionResult Index(string id)
        {
            var lecture = _mediator.Send(new GetTalkRequest(id));

            ViewBag.Title = lecture == null ? "Lecture Not Found" : lecture.Title;

            return View(lecture);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new Presentation();
            return View(model);    
        }

        [Authorize, HttpPost]
        public ActionResult Create(Presentation model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var request = _mapper.Map<CreatePresentationRequest>(model);
            var result = _mediator.Send(request);

            return RedirectToAction("Created", new {id = result});
        }

        public ActionResult Created(long id)
        {
            return View(new PresentationCreated(id));
        }

        public ActionResult Delete(long id)
        {
            return View(new DeletePresentation(id, User.Identity.Name));
        }

        [HttpPost]
        public ActionResult Delete(DeletePresentation model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var request = _mapper.Map<DeletePresentationRequest>(model);
            _mediator.Send(request);

            return RedirectToAction("Deleted");

        }

        public ActionResult Deleted()
        {
            return View();
        }

        public ActionResult Edit(long id)
        {
            throw new System.NotImplementedException();
        }

        
    }
}