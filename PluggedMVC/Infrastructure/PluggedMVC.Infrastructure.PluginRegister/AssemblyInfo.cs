using System.Web;

[assembly: PreApplicationStartMethod(typeof(PluggedMVC.Infrastructure.PluginRegister.PreApplicationInit), "InitializePlugins")]
