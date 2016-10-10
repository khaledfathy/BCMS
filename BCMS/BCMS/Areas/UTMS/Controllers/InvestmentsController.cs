using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    public class InvestmentsController : Controller
    {
        // GET: UTMS/Investments
        public ActionResult Index()
        {
            return View();
        }
    }
}