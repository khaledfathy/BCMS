using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.Games.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GameIndex()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MemeoryGame()
        {

            return View();
        }
        public ActionResult SpaceGame()
        {

            return View();
        }


    }
}