using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Domain
{
    public class ChecklistType
    {
        public int ChecklistTypeId { get; set; }
        public int ChecklistId { get; set; }
        public int ReleaseTypeId { get; set; }
        public ChecklistQuestion ChecklistEntity { get; set; }
        public ReleaseType ReleaseTypeEntity { get; set; }    
    }
}
