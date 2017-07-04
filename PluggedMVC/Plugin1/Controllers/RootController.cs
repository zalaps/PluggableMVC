using Plugin1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plugin1.Controllers
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