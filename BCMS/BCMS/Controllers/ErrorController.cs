using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View("NotFound");
        }

        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View("InternalServer");
        }
    }
}