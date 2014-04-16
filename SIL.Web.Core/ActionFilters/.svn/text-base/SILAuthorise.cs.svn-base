using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SIL.Web.Core
{
    public class SILAuthorise : AuthorizeAttribute
    {
        public SILAuthorise(params string[] roles)
        {
            this.Roles = string.Join(",", roles);
        }
    }
}
