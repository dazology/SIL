using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Domain
{
    public class ReleaseInfo
    {
        public int ReleaseInfoId { get; set; }
        public int ReleaseId {get; set;}
    }
}
