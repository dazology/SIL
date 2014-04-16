using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SIL.Web.Core.Models;
using SIL.Web.Core.Extensions;

namespace SIL.Web.Core.ActionFilters
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UserModel userModel;
            if (filterContext.Controller.ViewBag.UserModel == null)
            {
                userModel = new UserModel();
                filterContext.Controller.ViewBag.UserModel = userModel;
            }
            else
            {
                userModel = filterContext.Controller.ViewBag.UserModel as UserModel;
            }
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                SILUser silUser = filterContext.HttpContext.User.GetSilUser();
                userModel.IsUserAuthenticated = silUser.IsAuthenticated;
                userModel.UserName = silUser.DisplayName;
                userModel.RoleName = silUser.RoleName;
            }

            base.OnActionExecuted(filterContext);
        }
    }

    public class UserModel
    {
        public bool IsUserAuthenticated { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }

}
