using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIL.Web.Helpers;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Checklist;
using SIL.Web.ViewModels;


namespace SIL.Web.Controllers
{
    public class ChecklistController : Controller
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IReleaseTypeRepository _releaseTypeRepository;
        private readonly ICommandBus _commandBus;

        public ChecklistController(ICommandBus commandBus, IChecklistRepository repo, IReleaseTypeRepository releaseTypeRepository)
        {
            this._checklistRepository = repo;
            this._releaseTypeRepository = releaseTypeRepository;
            this._commandBus = commandBus;
        }

        public ActionResult Index()
        {
            var checklists = _checklistRepository.GetAll();
            return View(checklists);
        }
        public ActionResult Create()
        {
            var viewModel = new ChecklistViewModel();
            
            var check = _checklistRepository.GetAll();
            var rt = _releaseTypeRepository.GetAll();

            rt.ToSelectItemList(r => r.Name, r => r.Name);
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ChecklistViewModel cVm)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ChecklistViewModel, CreateOrUpdateChecklistCommand>(cVm);
                var result = _commandBus.Submit(command);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }
                
            ChecklistViewModel.FieldOptions d = cVm.QuestionFieldOptions;

            if (cVm.ChecklistId == 0)
            {
                cVm.QuestionFieldOptions = d;
                return View("Create", cVm);
            }
            else
            {
                return View("Edit", cVm);
            }
        }

    }
}
