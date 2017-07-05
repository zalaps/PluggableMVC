using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.Core.Plugable
{
    public interface IPlugableModule
    {
        /// <summary>
        /// Title of the plugin, can be used as a property to display on the user interface
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Name of the plugin, should be an unique name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Version of the loaded plugin
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Entry controller name
        /// </summary>
        string EntryControllerName { get; }

        /// <summary>
        /// Enumeration of registered css files from the assembly
        /// </summary>
        IEnumerable<string> RegisteredCss { get; }

        /// <summary>
        /// Enumeration of the registered JavaScript fiels from the assembly
        /// </summary>
        IEnumerable<string> RegisteredJavaScript { get; }

        /// <summary>
        /// Installs the plugin with all the scripts, css and DI 
        /// </summary>
        void Install();
    }
}
