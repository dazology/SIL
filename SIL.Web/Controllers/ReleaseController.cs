using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Service.Commands.Release;
using SIL.Web.ViewModels;
using SIL.Web.Helpers;
using SIL.Domain;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;

namespace SIL.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class ReleaseController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IReleaseTypeRepository _releaseTypeRepository;
        private readonly IReleaseRepository _releaseRepository;
        private readonly IWebsiteRepository _websiteRepository;

        public ReleaseController(ICommandBus commandBus, IWebsiteRepository websiteRepository, IReleaseRepository releaseRepository, IReleaseTypeRepository releaseTypeRepository)
        {
            this._websiteRepository = websiteRepository;
            this._commandBus = commandBus;
            this._releaseRepository = releaseRepository;
            this._releaseTypeRepository = releaseTypeRepository;
        }

        public ActionResult Index()
        {
            var release = _releaseRepository.GetAll();

            //set start date and end date to ViewBag dictionary
            ViewBag.LiveDate = DateTime.Now.ToShortDateString();
    
            return View(release);
        }

        public ActionResult Details(int id =0)
        {
            //var website = _websiteAcceessor.Repo.Find(id);
            return View();
        }


        public ActionResult Create()
        {
            var viewModel = new ReleaseViewModel();
            var web = _websiteRepository.GetAll();
            var rt = _releaseTypeRepository.GetAll();
            var rts = new ReleaseType();
            viewModel.RType = rt.ToSelectItemList( r => r.Name, r => r.ReleaseTypeId.ToString());
            viewModel.Websites = web.ToSelectListOfWebsites(-1);
            viewModel.DevDate = DateTime.Now;
            viewModel.StagingDate = DateTime.Now;
            viewModel.LiveDate = DateTime.Now;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ReleaseViewModel rh)
        {

            if (ModelState.IsValid)
            {

                //ReleaseViewModel.StatusList d = rh.Statuses;

                //rh.Statuses = rh.Statuses;
                var command = Mapper.Map<ReleaseViewModel, CreateOrUpdateReleaseCommand>(rh);
                var result = _commandBus.Submit(command);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            var web = _websiteRepository.GetAll();
            var rt = _releaseTypeRepository.GetAll();
            rh.Websites = web.ToSelectListOfWebsites(rh.ReleaseId);
            rh.RType = rt.ToSelectItemList(r => r.Name, r => r.ReleaseTypeId.ToString());


            if (rh.ReleaseId  == 0)
            {
                return View("Create", web);
            }
            else
            {
                return View("Edit", web);
            }            
        }

        public ActionResult Edit(int id)      
        {
            var release = _releaseRepository.GetById(id);
            var viewModel = Mapper.Map<Release, ReleaseViewModel>(release);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, Website web)
        {
           // _websiteAcceessor.Repo.InsertOrUpdate(web);
            //_websiteAcceessor.Save();
            return RedirectToAction("Index");
        }
    }
}
