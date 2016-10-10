using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    public class TraderController : Controller
    {
        //
        // GET: /UTMS/Trader/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _OneMin()
        {
            return PartialView();
        }

    }
}
