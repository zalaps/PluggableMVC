using PluggedMVC.Core.Plugable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.WebPlugins.ClassLibraryTemplate
{
    public class ClassLibraryPlugableModule : IPlugableModule
    {
        public string EntryControllerName
        {

            get { return "PluggedMVC.WebPlugins.ClassLibraryTemplate"; }

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
            get { return "PluggedMVC.WebPlugins.ClassLibraryTemplate"; }
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
