using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluginRegister
{
    public class PluginManager
    {
        public PluginManager()
        {
            Modules = new Dictionary<IModule, Assembly>();
        }

        internal Dictionary<IModule, Assembly> Modules { get; set; }

        private static PluginManager _current;
        public static PluginManager Current
        {
            get { return _current ?? (_current = new PluginManager()); }
        }
        
        public IEnumerable<IModule> GetModules()
        {
            return Modules.Select(m => m.Key).ToList();
        }

        public IModule GetModule(string name)
        {
            return GetModules().FirstOrDefault(m => m.Name == name);
        }
    }
}
