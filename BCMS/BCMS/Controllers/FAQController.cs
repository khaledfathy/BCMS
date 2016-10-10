using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using System.Threading;

namespace BCMS.Controllers
{
    public class FAQController : Controller
    {

        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        public JsonResult GetAllFAQ()
        {
            var model = DB.Faqs.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
