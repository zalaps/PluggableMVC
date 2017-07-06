using PluggedMVC.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.Core.Service
{
    public interface IPersonService 
    {
        List<PersonViewModel> GetAllPersons();
    }
}
