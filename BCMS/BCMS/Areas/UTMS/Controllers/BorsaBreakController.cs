using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    public class BorsaBreakController : Controller
    {
        //
        // GET: /UTMS/BorsaBreak/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Magazines()
        {
            return View();
        }

        public ActionResult Television()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
    }
}
