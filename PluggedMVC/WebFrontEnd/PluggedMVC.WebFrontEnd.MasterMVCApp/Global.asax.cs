using Castle.MicroKernel.Registration;
using PluggedMVC.Core.Data.Base;
using PluggedMVC.Core.Service;
using PluggedMVC.Infrastructure.Data;
using PluggedMVC.Infrastructure.PluginRegister;
using PluggedMVC.WebFrontEnd.MasterMVCApp.AppCode;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PluggedMVC.WebFrontEnd.MasterMVCApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Install();
            PluginBootstrapper.Initialize();

            var container = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<Castle.Windsor.IWindsorContainer>();

            container.Register(AllTypes.Of<IController>().FromAssembly(Assembly.GetExecutingAssembly())
                .LifestyleTransient());

            //Hardcoded resolution
            //container.Register(AllTypes.FromAssembly(typeof(PersonService).Assembly)
            //    .BasedOn<IBaseService>()
            //    .WithService.FromInterface()
            //    .LifestyleTransient());

            container.Register(
                AllTypes.FromAssemblyNamed("PluggedMVC.Infrastructure.Repository")
                .Where(type => type.IsPublic)
                .WithService.AllInterfaces()
                .LifestyleTransient());

            container.Register(
                AllTypes.FromAssemblyNamed("PluggedMVC.Infrastructure.Service")
                .Where(type => type.IsPublic)
                .WithService.FirstInterface()
                .LifestyleTransient());

            container.Register(
                Component.For<AdventureWorksEntities>()
                .ImplementedBy<AdventureWorksEntities>()
                .LifeStyle.PerWebRequest);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
