using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Domain;
using SIL.Service.Commands.Website;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;
using SIL.Web.Helpers;
using SIL.Web.ViewModels;

namespace SIL.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class WebsiteController : Controller
    {
        //
        // GET: /Website/

        private readonly ICommandBus commandBus;
        private readonly IWebsiteRepository websiteRepository;
        private readonly ICompanyRepository customerRepository;
        private readonly IServerRepository serverRepository;
        private readonly IIpRepository ipRepository;


        public WebsiteController(ICommandBus commandBus, IWebsiteRepository websiteRepository, ICompanyRepository customerRepository, IIpRepository ipRepository, IServerRepository serverRepository)
        {
            this.websiteRepository = websiteRepository;
            this.commandBus = commandBus;
            this.customerRepository = customerRepository;
            this.ipRepository = ipRepository;
            this.serverRepository = serverRepository;
        }

        public ActionResult Index()
        {
            var websites = websiteRepository.GetAll();
            return View("Index",websites);
        }

        public ActionResult Details(int id =0)
        {
            var web = websiteRepository.GetById(id);
            var viewModel = Mapper.Map<Website, WebsiteViewModel>(web);
            var servers = serverRepository.GetAll();
            var ips = ipRepository.GetAll();
            var customers = customerRepository.GetAll();


            //viewModel.Servers = servers.ToSelectListOfServers(web.ServerId);
            viewModel.Ips = ips.ToSelectListOfIps(web.IpId);
            viewModel.Customers = customers.ToSelectListOfCustomers(web.CustomerId);
            return View(viewModel);
        }


        public ActionResult Create()
        {
            var viewModel = new WebsiteViewModel();
            var customers = customerRepository.GetAll();
 
            var ips = ipRepository.GetAll();

            viewModel.Customers = customers.ToSelectListOfCustomers(-1);
       //     viewModel.Servers = servers.ToSelectListOfServers(-1);
            viewModel.Ips = ips.ToSelectListOfIps(-1);

            viewModel.SupportUsername = " ";
 
            return View(viewModel);
        }
       

        [HttpPost]
        public ActionResult Save(WebsiteViewModel web)
        {

            if (ModelState.IsValid)
            {
                var command = Mapper.Map<WebsiteViewModel, CreateOrUpdateWebsiteCommand>(web);
                var result = commandBus.Submit(command);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            // Would ideally like to do one call to get everything - Looking into

            var servers = serverRepository.GetAll();
            var ips = ipRepository.GetAll();
            var customers = customerRepository.GetAll();

            web.Customers = customers.ToSelectListOfCustomers(web.CustomerId);       
            //web.Servers = servers.ToSelectListOfServers(web.ServerId);
            web.Ips = ips.ToSelectListOfIps(web.IpId);
        
            if (web.WebsiteId == 0)
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
            var web = websiteRepository.GetById(id);
            var viewModel = Mapper.Map<Website, WebsiteViewModel>(web);

            var ips = ipRepository.GetAll();
            var customers = customerRepository.GetAll();

            viewModel.Customers = customers.ToSelectListOfCustomers(web.CustomerId);
            viewModel.Ips = ips.ToSelectListOfIps(web.IpId);
            return View(viewModel);


        }


    
        public ActionResult Delete(int id)
        {
            var command = new DeleteWebsiteCommand { WebsiteId = id };            
            var result = commandBus.Submit(command);
            var websites = websiteRepository.GetAll();
            return View(websites);

        }

    }
}
