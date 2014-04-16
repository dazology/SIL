using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIL.Web.ViewModels
{
    public class WebsiteServerViewModel
    {
        public int WebsiteId { get; set; }
        public int ServerId { get; set; }
        public string DatabaseName { get; set; }
        public string Version { get; set; }
        public string SiteName { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
    }
}