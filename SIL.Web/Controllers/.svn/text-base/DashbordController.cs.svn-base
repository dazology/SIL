using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;

namespace SIL.Web.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class DashbordController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly IWebsiteRepository websiteRepository;
        private readonly IServerRepository serverRepository;

        public DashbordController(IWebsiteRepository websiteRepository, IServerRepository serverRepository, ICommandBus commandBus)
        {
            this.websiteRepository = websiteRepository;
                this.serverRepository = serverRepository;
                this.commandBus = commandBus;
        }

        public ActionResult Index()
        {
          var websites =  websiteRepository.GetAll();
         var  servers =  serverRepository.GetAll();

         //var pair = from a in websites
         //           from b in servers
         //           where a.ServerId == b.ServerId
         //           select new { a, b };

         return View();
        }

    }
}
