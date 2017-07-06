using PluggedMVC.Core.Model;
using PluggedMVC.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluggedMVC.WebFrontEnd.MasterMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService personService;

        public HomeController(IPersonService service)
        {
            this.personService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is About view from Master MVC App.";
            var data = personService.GetAllPersons();
            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}