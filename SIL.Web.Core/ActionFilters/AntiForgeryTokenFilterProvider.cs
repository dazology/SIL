using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SIL.Web.Core.ActionFilters
{
    public class AntiForgeryTokenFilterProvider : System.Web.Mvc.IFilterProvider
    {
        public IEnumerable<System.Web.Mvc.Filter> GetFilters(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ActionDescriptor actionDescriptor)
        {
            List<Filter> result = new List<Filter>();

            string incomingVerb = controllerContext.HttpContext.Request.HttpMethod;

            if (String.Equals(incomingVerb, "POST", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(new Filter(new ValidateAntiForgeryTokenAttribute(), FilterScope.Global, null));
            }

            return result;
        }
    }
}
