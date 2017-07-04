using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PluggedMVC.Startup))]
namespace PluggedMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
