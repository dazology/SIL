using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Domain
{
    public class WebsiteReference
    {
        [Key]
        public int Id { get; set; }
        public string SiteName { get; private set;  }
        public string URL { get;  private set; }
        public bool IsActive { get; set; }
    }
}
