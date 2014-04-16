using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using SIL.Domain;
using System.Web.Mvc;
using SIL.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace SIL.Web.ViewModels
{
    public class WebsiteViewModel
    {
        public int WebsiteId { get; set; }
        public int CustomerId { get; set; }
        public int IpId { get; set; }


        public virtual IEnumerable<System.Web.Mvc.SelectListItem> Ips { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Customers { get; set; }

        public string WebsitePath { get; set; }
        public string WebsiteFolder { get; set; }
        public string DatabaseName { get; set; }
        public string Version { get; set; }
        public string SiteName { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
        public bool DomainControl { get; set; }
        public string ServerName { get; set; }
        public string SupportUsername { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SupportPasswordHash { get; set; }
        //public string Password
        //{
        //    set { SupportPasswordHash = Md5Encrypt.Md5EncryptPassword(value); }
        //}
        public string Comments { get; set; }
        public bool Pingdom { get; set; }
 
     
         
    }
}