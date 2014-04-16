using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.ReleaseType;
using SIL.Web.ViewModels;

namespace SIL.Web.Controllers
{
    public class ReleaseTypeController : Controller
    {
        private readonly IReleaseTypeRepository _releaseTypeRepository;
        private readonly ICommandBus _commandBus;

        public ReleaseTypeController(ICommandBus commandBus, IReleaseTypeRepository releaseTypeRepository)
        {
            this._releaseTypeRepository = releaseTypeRepository;
            this._commandBus = commandBus;
        }

        public ActionResult Index()
        {
            var rt = _releaseTypeRepository.GetAll();
            return View(rt);
        }



        public ActionResult Create()
        {
            var rt = new ReleaseTypeViewModel();

            return View(rt);
        }

        [HttpPost]
        public ActionResult Create(ReleaseTypeViewModel rt)
        {

            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ReleaseTypeViewModel, CreateOrUpdateReleaseTypeCommand>(rt);
                var result = _commandBus.Submit(command);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }

          
            if (rt.ReleaseTypeId == 0)
            {
                return View("Create", rt);
            }
            else
            {
                return View("Edit", rt);
            }
        }


    }
}
