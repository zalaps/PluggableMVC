using Castle.MicroKernel.Registration;
using Castle.Windsor;
//using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using PluggedMVC.Infrastructure.PluginRegister;

namespace PluggedMVC.WebFrontEnd.MasterMVCApp.AppCode
{
    public static class Bootstrapper
    {
        private static IWindsorContainer Container { get; set; }
        public static void Install()
        {
            Container = new WindsorContainer();

            Container.Register(Component.For<IWindsorContainer>().Instance(Container).LifestyleSingleton());
            Container.Register(AllTypes.Of<System.Web.Mvc.IController>().FromAssembly(System.Reflection.Assembly.GetExecutingAssembly()).LifestyleTransient());

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(Container));
            Container.Register(Component.For<IServiceLocator>().Instance(ServiceLocator.Current).LifestyleSingleton());

            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));
        }
    }
}
