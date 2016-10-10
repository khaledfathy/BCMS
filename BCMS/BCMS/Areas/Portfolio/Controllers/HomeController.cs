using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.Portfolio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Portfolio/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PortfolioAnalyses()
        {
            return View();
        }
    }
}