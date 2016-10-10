using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: UTMS/Home
        public ActionResult Index()
        {
            return View();
        }

    }
}