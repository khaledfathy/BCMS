using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    public class HelpToolsController : Controller
    {
        // GET: UTMS/HelpTools
        public ActionResult TradingTime()
        {
            return View();
        }
    }
}