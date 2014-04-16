using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIL.Web.ViewModels
{
    public class DashboardWebViewModel
    {
        public int WebsiteId { get; set; }
        public int CustomerId { get; set; }
        public int IpId { get; set; }
        
        public string WebsiteName { get; set; }
        public string URL { get; set; }
        public string ContactName { get; set; }
        public string CustomerName { get; set; }
        public string IPAddress { get; set; }
        public string TelNo { get; set; }

    }
}