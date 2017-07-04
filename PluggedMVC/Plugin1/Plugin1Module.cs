using PluginRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugin1
{
    public class Plugin1Module : IModule
    {
        public string EntryControllerName
        {
           
                get { return "Plugin1"; }
           
        }

        public string Name
        {
            get { return Assembly.GetAssembly(GetType()).GetName().Name; }
        }

        public IEnumerable<string> RegisteredCss
        { get; private set; }

        public IEnumerable<string> RegisteredJavaScript
        { get; private set; }

        public string Title
        {
            get { return "Plugin1"; }
        }

        public Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }

        public void Install()
        {
           
        }
    }
}
