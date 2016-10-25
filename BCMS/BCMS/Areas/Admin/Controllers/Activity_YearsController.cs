using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;
using BCMS.Models;

namespace BCMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Activity_YearsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
                        ViewBag.AllActivity= new SelectList(DB.Activities.Select(e => new { e.ActivityId, e.ActivityArName }), "ActivityId", "ActivityArName");

            Session["PageTitle"] = "السنوات النشطة";
        
            if (id != 0)
            {
                var model = DB.Activity_Year.Where(s => s.ActivityId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                 var model = DB.Activity_Year.ToList().ToPagedList(page ?? 1, 10);
            return View(model);
            }
        }
        
        public ActionResult Create()
        {
            ViewBag.AllActivity = new SelectList(DB.Activities.Select(e => new { e.ActivityId, e.ActivityArName }), "ActivityId", "ActivityArName");
            ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Activity_Year Activity_Year)
        {
            if (ModelState.IsValid)
            {
           
                DB.Activity_Year.Add(Activity_Year);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Activity_Year);
        }

        [HttpGet]
        public ActionResult Edit(int id,int yearID)
        {
            Activity_Year ws = DB.Activity_Year.FirstOrDefault(x => x.ActivityId == id && x.YearId == yearID);
            if (ws != null)
            {
                ViewBag.AllActivity = new SelectList(DB.Activities.Select(e => new { e.ActivityId, e.ActivityArName }), "ActivityId", "ActivityArName");
                ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Activity_Year Activity_Year)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Activity_Year).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Activity_Year);
        }

        [HttpGet]
        public ActionResult Delete(int id,int yearID)
        {
            Activity_Year ws = DB.Activity_Year.FirstOrDefault(x => x.ActivityId == id && x.YearId == yearID);


            if (ws != null)
            {
                DB.Activity_Year.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id,int yearID)
        {
            Activity_Year ws = DB.Activity_Year.FirstOrDefault(x => x.ActivityId == id && x.YearId == yearID);

            if (ws != null)
            {
                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
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
