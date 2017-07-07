using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PluggedMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.WebFrontEnd.Resolver
{
    public static class Injector
    {    
        public static void Inject()
        {
            var container = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<Castle.Windsor.IWindsorContainer>();

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
        }
    }
}
