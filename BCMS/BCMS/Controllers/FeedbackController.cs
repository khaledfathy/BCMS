using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;

namespace BCMS.Controllers
{
    public class FeedbackController : Controller
    {

        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        public JsonResult Send(Feedback feedback)
        {
            try
            {
                DB.Feedbacks.Add(feedback);
                if (DB.SaveChanges() > 0)
                    return Json(new { msg = true }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { msg = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { msg = false }, JsonRequestBehavior.AllowGet);
            }
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
