using PluggedMVC.Core.Plugable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.Infrastructure.PluginRegister
{
    public class PluginManager
    {
        public PluginManager()
        {
            Modules = new Dictionary<IPlugableModule, Assembly>();
        }

        internal Dictionary<IPlugableModule, Assembly> Modules { get; set; }

        private static PluginManager _current;
        public static PluginManager Current
        {
            get { return _current ?? (_current = new PluginManager()); }
        }
        
        public IEnumerable<IPlugableModule> GetModules()
        {
            return Modules.Select(m => m.Key).ToList();
        }

        public IPlugableModule GetModule(string name)
        {
            return GetModules().FirstOrDefault(m => m.Name == name);
        }
    }
}
