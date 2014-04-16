using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Service.Commands.CustomChecks;
using SIL.Web.ViewModels;
using SIL.Web.Helpers;

namespace SIL.Web.Controllers
{
    public class CustomCheckController : Controller
    {
        private ICommandBus _commandBus;
        private ICustomCheckRepository _customCheckRepository;
        private readonly IWebsiteRepository _websiteRepository;

        public CustomCheckController(ICommandBus commandBus, ICustomCheckRepository customCheckRepository, IWebsiteRepository websiteRepository)
        {
            this._commandBus = commandBus;
            this._customCheckRepository = customCheckRepository;
            this._websiteRepository = websiteRepository;
        }

        public ActionResult Index()
        {
           var cc = _customCheckRepository.GetAll();
            return View(cc);
        }


        public ActionResult Create()
        {
            var viewModel = new CustomCheckViewModel();
       
            var web = _websiteRepository.GetAll();
            viewModel.Websites = web.ToSelectItemList(w => w.SiteName, w => w.WebsiteId.ToString());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomCheckViewModel ccvm)
        {
            var command = Mapper.Map<CustomCheckViewModel, CreateOrUpdateCustomCheckCommand>(ccvm);

            if (ModelState.IsValid)
            {
                var result = _commandBus.Submit(command);
                if (result.Success) return RedirectToAction("Index");
            }

            if (ccvm.CustomChecksId == 0)
                return View("Create", ccvm);
            else
                return View("Edit", ccvm);
        }

    }
}
