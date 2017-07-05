using System.Web;
using System.Web.Mvc;

namespace PluggedMVC.WebFrontEnd.MasterMVCApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
