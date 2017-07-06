using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.Core.Data.Base
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
