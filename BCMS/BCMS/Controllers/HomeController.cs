using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;

namespace BCMS.Controllers
{
    public class HomeController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
