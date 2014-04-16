using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.Ip;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;
using SIL.Web.ViewModels;
using SIL.Web.Helpers;

namespace SIL.Web.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class IpController : Controller
    {
         private readonly ICommandBus _commandBus;
        private readonly IIpRepository _ipRepository;
        private readonly IServerRepository _serverRepository;

        public IpController(ICommandBus commandBus, IIpRepository ipRepository, IServerRepository serverRepository)
        {
            this._commandBus = commandBus;
            this._ipRepository = ipRepository;
            _serverRepository = serverRepository;
        }

        public ActionResult Index()
        {
            var ips = _ipRepository.GetAll();
            return View(ips);
        }


        public ActionResult Create()
        {
            var viewModel = new IpViewModel();

            var servers = _serverRepository.GetAll();
            viewModel.Servers = servers.ToSelectListOfServers(-1);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(IpViewModel ipVw)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<IpViewModel, CreateOrUpdateIpCommand>(ipVw);
                var result = _commandBus.Submit(command);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            var servers = _serverRepository.GetAll();
            ipVw.Servers = servers.ToSelectListOfServers(ipVw.ServerId);

            ////c.Contacts = contact.ToSelectListOfContacts(ipVw.);
            if (ipVw.IpId == 0)
            {
                return View("Create", ipVw);
            }
            else
            {
                return View("Edit", ipVw);
            }
        }

        public ActionResult Edit(int id)
        {
            var ip = _ipRepository.GetById(id);
            var servers = _serverRepository.GetAll();

            var viewModel = Mapper.Map<IP, IpViewModel>(ip);

            viewModel.Servers = servers.ToSelectListOfServers(ip.ServerId);

            return View(viewModel);
        }



        public ActionResult Delete(int id)
        {
            var command = new DeleteIpCommand { IpId = id };
            var result = _commandBus.Submit(command);
            var ip = _ipRepository.GetAll();
            return View(ip);
        }

        public ActionResult Details(int id = 0)
        {
            var server = _ipRepository.GetById(id);
            var viewModel = Mapper.Map<IP, IpViewModel>(server);
            return View(viewModel);
        }


    }
}
