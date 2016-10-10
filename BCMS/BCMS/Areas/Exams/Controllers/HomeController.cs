using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using BCMS.RegisterService;

namespace BCMS.Areas.Exams.Controllers
{
    public class HomeController : Controller
    {
        BorsaCapitalDB DB = new BorsaCapitalDB();
        public object getmaxcategory(int id,int defualtid,string user)
        {
            object maxcategory;
             var youritem = DB.ExamResults.Where(x => x.username == user && x.ExamSubCategory.ExamCategory.id == id).Take(1).SingleOrDefault();
            if (youritem == null)
            {
               maxcategory= defualtid;
            }
            else
            {
                Nullable<int> Category = DB.ExamResults.OrderByDescending(x => x.subcategory_id).FirstOrDefault(e => e.username == user && e.ExamSubCategory.ExamCategory.id == id).subcategory_id + 1;
                maxcategory = Category;
            }
            return (maxcategory);
        }

        [HttpGet]
        public ActionResult Category()
        {

            if (Request.Cookies["mvcname"] != null)
            {
                string user = Request.Cookies["mvcname"]["Username"];
                Session["max_category"]=   getmaxcategory(1,1,user);
                Session["max_category2"]= getmaxcategory(2,6, user);
                Session["max_category3"]=  getmaxcategory(3,11, user);
                Session["max_category4"]=   getmaxcategory(4,16, user);
                Session["max_category5"]=   getmaxcategory(5,21, user);
                Session["max_category6"]=   getmaxcategory(6,26, user);
                Session["max_category7"]=   getmaxcategory(7,31,  user);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
           
        }
        [HttpGet]
        public JsonResult getcategory ()
        {
            string user = Request.Cookies["mvcname"]["Username"];
            var lst = DB.ExamResults.Select(x => new { x.username, x.subcategory_id }).Where(x => x.username == user).ToList();
            return Json(lst, JsonRequestBehavior.AllowGet);
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