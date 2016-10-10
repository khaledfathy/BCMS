using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using BCMS.RegisterService;

namespace BCMS.Areas.Exams.Controllers
{
    public class _HomeController : Controller
    {
        BorsaCapitalDB DB = new BorsaCapitalDB();

        [HttpGet]
        public ActionResult Category()
        {
           
            if (Request.Cookies["mvcname"] != null)
            {
                string user = Request.Cookies["mvcname"]["Username"];
                var yourItem = DB.ExamResults.Where(x => x.username == user).Take(1).SingleOrDefault();

                if (yourItem == null)
                {
                    Session["max_category"] = 1;
                }
                else
                {
                    Nullable<int> Category = DB.ExamResults.OrderByDescending(x => x.subcategory_id).FirstOrDefault(e => e.username == user).subcategory_id + 1;
                    Session["max_category"] = Category;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
           
        }
      
        [HttpGet]
        public ActionResult Exam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Exam(int category)
        {
            return View();
        }

      

        public ActionResult Chart()
        {
            string user = Request.Cookies["mvcname"]["Username"];
            var yourItem = DB.ExamResults.Where(x => x.username == user).Take(1).SingleOrDefault();
            if (yourItem == null)
            {
                Session["max_category"] = 1;
            }
            else
            {
                Nullable<int> Category = DB.ExamResults.OrderByDescending(x => x.subcategory_id).FirstOrDefault(e => e.username == user).subcategory_id + 1;
                Session["max_category"] = Category;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            Session["User"] = null;
            Session["username"] = null;
            Session["max_category"] = null;
            return RedirectToAction("Index", "Home");
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