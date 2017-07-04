using PluginRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PluggedMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Install();
            PluginBootstrapper.Initialize();
            var container = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<Castle.Windsor.IWindsorContainer>();
            container.Register(Castle.MicroKernel.Registration.AllTypes.Of<System.Web.Mvc.IController>().FromAssembly(System.Reflection.Assembly.GetExecutingAssembly()).LifestyleTransient());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
