using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.Core.Common;

namespace SIL.Domain
{
    public class Website
    {

        public int WebsiteId { get; set; }
        public int CustomerId { get; set; }
        public int IpId { get; set; }
        public virtual ICollection<CustomChecklist> Checks { get; set; }
        //One to many 
        public virtual ICollection<Release> Releases { get; set; }
        //many to many - link table creation
        public string WebsitePath { get; set; }
        public string WebsiteFolder{get; set; }
        public string  DatabaseName { get; set; }
        public string Version { get; set; }
        public string SiteName { get; set; }
        public string URL { get; set; }
        public bool IsActive { get; set; }
        public bool DomainControl { get; set; }
        public string SupportUsername { get; set; }
        public string SupportPasswordHash { get; set; }
        public string Password
        {
            set { SupportPasswordHash = Md5Encrypt.Md5EncryptPassword(value); }
        }  
        public string Comments { get; set; }
        public bool Pingdom { get; set; }
         

        public Website()
        {

        } 

    }
}
