using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;
using SIL.Web.ViewModels;
using Mvc.JQuery.Datatables;


namespace SIL.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class HomeController : Controller
    {

        private readonly ICommandBus commandBus;
        private readonly IWebsiteRepository _websiteRepository;
        private readonly IIpRepository _ipRepository;
        private readonly IReleaseRepository _releaseRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ICompanyRepository _companyRepository;

        public HomeController(IWebsiteRepository websiteRepository, IContactRepository contactRepository ,IIpRepository ipRepository, IReleaseRepository releaseRepository, ICompanyRepository companyRepository, ICommandBus commandBus)
        {
            this._websiteRepository = websiteRepository;
            this._ipRepository = ipRepository;
            _releaseRepository = releaseRepository;
            _contactRepository = contactRepository;
            _companyRepository = companyRepository;
            this.commandBus = commandBus;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult DashboardReleaseWidget()
        {
            var websites = _websiteRepository.GetAll();
            var releases = _releaseRepository.GetAll();

            var releaseInfo = (from r in releases
                           join w in websites on r.WebsiteId equals w.WebsiteId
                           select new DashboardReleaseViewModel
                           {
                                      StartDate = DateTime.Now,
                                        WebsiteName = w.SiteName,
                                        UnitOfWork = r.Notes,
                                        Dev = r.DevDate,
                                        Staging = r.StagingDate,
                                        Live = r.LiveDate,
                           }).Take(5);


            return PartialView(releaseInfo);
        }

  
 
        public ActionResult DashboardIPWidget()
        {
            var ips = _ipRepository.GetAll();
            return PartialView(ips);

        }

        public ActionResult DashboardContactWidget(JQueryDataTableParamModel param)
        {
            
            var contact = _contactRepository.GetAll().Take(5);

            var result = from c in contact
                         select new[] { Convert.ToString(c.ContactId), c.Name,
                          c.EmailAddress, c.TelNo };

            return PartialView(contact);
         // return Json(new  
         //{  
         //  sEcho = param.sEcho,
         //  aaData = result,  
         //  iTotalRecords =contact.Count(),
         //  iTotalDisplayRecords = contact.Count(),  
         //}, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DashboardWebWidget()
        {
            var contact = _contactRepository.GetAll();
            var websites = _websiteRepository.GetAll();
            var company = _companyRepository.GetAll();
            var ip = _ipRepository.GetAll();


            var contactinfo = (from w in websites
                               join cu in company on w.CustomerId equals cu.CustomerId
                               join c in contact on cu.CustomerId equals c.CustomerId
                               join i in ip on w.IpId equals i.IpId
                               select new DashboardWebViewModel
                               {

                                   WebsiteName = w.SiteName,
                                   URL = w.URL,
                                   IPAddress = i.InternalIPAddress,
                                   CustomerName = cu.Name,
                                   ContactName = c.Name,
                                   TelNo = c.TelNo,

                               }).Take(1);


            return PartialView(contactinfo);

        }


         public class JQueryDataTableParamModel  
  {  
   public string sEcho { get; set; }  
   public string sSearch { get; set; }  
   public int iDisplayLength { get; set; }  
   public int iDisplayStart { get; set; }  
  } 
    }
}
