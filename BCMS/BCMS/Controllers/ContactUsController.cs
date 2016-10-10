using BCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpPost]
        public JsonResult Send(ContactUs contactUs)
        {
            string result = EmailVerification.ContactUsMail(contactUs.name, contactUs.email, contactUs.subject, contactUs.message);
            return Json(new { msg = result }, JsonRequestBehavior.AllowGet);
        }

    }
}
