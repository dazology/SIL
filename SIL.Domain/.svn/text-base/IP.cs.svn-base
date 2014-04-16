using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIL.Domain
{
    public class IP
    {
        public int IpId { get; set; }
        public int ServerId { get; set; }
        public string ExternalIPAddress { get; set; }
        public string InternalIPAddress { get; set; }
        public string IISIPAddress { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }
        public bool  SSL {get; set;}
        public virtual ICollection<Website> Websites { get; set; }
        public IP()
        {

        }
    }
}