using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SIL.AutoMapper;
using System.Reflection;
using SIL.DataLayer;
using SIL.DataLayer.Repository;
using System.Web.Mvc;
using SIL.CommadProcessor.Command;
using SIL.CommadProcessor.Dispatcher;
using System.Web.Http;
using SIL.DataLayer.Repositories;
using SIL.Web.Core.Authentication;


namespace SIL.Web
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            AutoMapperBootstrapper.ConfigureMapping();
        }

        private static void SetAutofacContainer()
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork<SILContext>>().As<IUnitOfWork>();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(WebsiteRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerHttpRequest();
             var services = Assembly.Load("SIL.Service");
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(services)
            .AsClosedTypesOf(typeof(IValidationHandler<>)).InstancePerHttpRequest();
           builder.RegisterType<DefaultFormsAuthentication>().As<IFormsAuthentication>().InstancePerHttpRequest();
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            

                  

        }
    }
}