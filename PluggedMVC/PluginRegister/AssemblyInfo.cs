using System.Web;

[assembly: PreApplicationStartMethod(typeof(PluginRegister.PreApplicationInit), "InitializePlugins")]
