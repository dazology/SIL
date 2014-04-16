using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Service.Commands.Server;
using SIL.Web.ViewModels;
using SIL.Web.Helpers;
using SIL.Domain;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;

namespace SIL.Web.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class ServerController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IServerRepository _serverRepository;

        public ServerController(ICommandBus commandBus, IWebsiteRepository ipRepository, IServerRepository serverRepository)
        {
            this._commandBus = commandBus;
            this._serverRepository = serverRepository;
        }

        public ActionResult Index()
        {
            var server = _serverRepository.GetAll();
            return View(server);
        }


        public ActionResult Create()
        {
            var viewModel = new ServerViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(ServerViewModel serv)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<ServerViewModel, CreateOrUpdateServerCommand>(serv);
                var result = _commandBus.Submit(command);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }


            //web.Customer = serv..To(serv.WebsiteId);
            if (serv.ServerId == 0)
            {
                return View("Create", serv);
            }
            else
            {
                return View("Edit", serv);
            }
        }

        public ActionResult Edit(int id)
        {
            var serv = _serverRepository.GetById(id);
            var viewModel = Mapper.Map<Server, ServerViewModel>(serv);
            return View(viewModel);
        }



        public ActionResult Delete(int id)
        {
            var command = new DeleteServerCommand { ServerId = id };
            var result = _commandBus.Submit(command);
            var server = _serverRepository.GetAll();
            return View(server);
        }

        public ActionResult Details(int id = 0)
        {
            var server = _serverRepository.GetById(id);
            var viewModel = Mapper.Map<Server, ServerViewModel>(server);
            return View(viewModel);
        }


    }
}
