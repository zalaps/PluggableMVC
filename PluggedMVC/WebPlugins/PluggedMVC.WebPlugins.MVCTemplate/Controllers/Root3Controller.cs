using PluggedMVC.Core.Model;
using PluggedMVC.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluggedMVC.WebPlugins.MVCTemplate.Controllers
{
    public class Root3Controller : Controller
    {
        private readonly IPersonService personService;

        public Root3Controller(IPersonService service)
        {
            this.personService = service;
        }

        // GET: Root3
        public ActionResult Index()
        {
            //return View();
            var data = personService.GetAllPersons();
            return View(data);
        }
    }
}