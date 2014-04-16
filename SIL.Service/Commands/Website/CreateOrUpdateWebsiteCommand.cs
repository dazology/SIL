using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;
using SIL.Core.Common;

namespace SIL.Service.Commands.Website
{
    public class CreateOrUpdateWebsiteCommand : ICommand
    {
        public int WebsiteId { get; set; }
        public int CustomerId { get; set; }
        public int IpId { get; set; }
        public string SiteName { get; set; }
        public string WebsitePath { get; set; }
        public string WebsiteFolder { get; set; }
        public string DatabaseName { get; set; }
        public string Version { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
        public bool DomainControl { get; set; }
        public string ServerName { get; set; }
        public string SupportUsername { get; set; }
        public string SupportPasswordHash { get; set; }
        public string Comments { get; set; }
        public bool Pingdom { get; set; }
 
    }
}
