using PluggedMVC.WebPlugins.ClassLibraryTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluggedMVC.WebPlugins.ClassLibraryTemplate.Controllers
{
    public class RootController : Controller
    {
        public ActionResult Index()
        {
            var r = new RootModel();
            r.PhoneNumber = "456";
            return View(r);
        }
   
    }
}