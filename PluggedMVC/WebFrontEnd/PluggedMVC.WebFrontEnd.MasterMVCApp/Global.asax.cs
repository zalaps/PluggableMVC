using Castle.MicroKernel.Registration;
using Microsoft.Practices.ServiceLocation;
using PluggedMVC.Core.Data.Base;
using PluggedMVC.Core.Service;
using PluggedMVC.Infrastructure.PluginRegister;
using PluggedMVC.WebFrontEnd.MasterMVCApp.AppCode;
using PluggedMVC.WebFrontEnd.Resolver;
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
            Injector.Inject();
            
            var container = ServiceLocator.Current.GetInstance<Castle.Windsor.IWindsorContainer>();
            container.Register(AllTypes.Of<IController>().FromAssembly(Assembly.GetExecutingAssembly())
                .LifestyleTransient());           

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
