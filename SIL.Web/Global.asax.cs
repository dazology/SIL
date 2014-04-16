using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SIL.DataLayer;
using SIL.DataLayer.Migrations;
using SIL.Web;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Authentication;
using SIL.Web.Core.Models;

namespace SIL
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           filters.Add(new UserFilter()); 

        }

        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.MapRoute(
           name: "Default",
           url: "{controller}/{action}/{id}",
           defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            //Database.SetInitializer(new DbInitialize());

                using (var context = new SILContext())
            {
                //context.Database.Delete();
                //context.Database.Create();
                //// Or
                //context.Database.CreateIfNotExists();

                //context.Database.Initialize(true);
            }


            //AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            Bootstrapper.Run();

        }

        public override void Init()
        {
            this.PostAuthenticateRequest += this.PostAuthenticateRequestHandler;
            base.Init();
        }

        private void PostAuthenticateRequestHandler(object sender, EventArgs e)
        {
            HttpCookie authCookie = this.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (IsValidAuthCookie(authCookie))
            {
                var formsAuthentication = DependencyResolver.Current.GetService<IFormsAuthentication>();


                var ticket = formsAuthentication.Decrypt(authCookie.Value);
                var silUser = new SILUser(ticket);
                string[] userRoles = { silUser.RoleName };
                this.Context.User = new GenericPrincipal(silUser, userRoles);
                formsAuthentication.SetAuthCookie(this.Context, ticket);
            }
        }

        private static bool IsValidAuthCookie(HttpCookie authCookie)
        {
            return authCookie != null && !String.IsNullOrEmpty(authCookie.Value);
        }

    }
}