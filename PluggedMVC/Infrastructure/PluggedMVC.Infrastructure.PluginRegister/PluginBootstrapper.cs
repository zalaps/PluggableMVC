using BoC.Web.Mvc.PrecompiledViews;

namespace PluggedMVC.Infrastructure.PluginRegister
{
    public static class PluginBootstrapper
    {
        static PluginBootstrapper()
        {

        }

        public static void Initialize()
        {
            foreach (var module in PluginManager.Current.Modules.Keys)
            {                
                var assembly = PluginManager.Current.Modules[module];
                ApplicationPartRegistry.Register(PluginManager.Current.Modules[module]);
                module.Install();
                var container = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<Castle.Windsor.IWindsorContainer>();
                container.Register(Castle.MicroKernel.Registration.AllTypes.Of<System.Web.Mvc.IController>().FromAssembly(assembly).LifestyleTransient());
            }
        }
    }
}
