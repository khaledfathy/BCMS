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
    public class WiseSayingController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "أقوال الحكماء";
            var model = DB.WiseSayings.ToList().ToPagedList(page ?? 1, 10);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllElders = new SelectList(DB.Elders.Select(e => new { e.EldersID, e.EldersName }), "EldersID", "EldersName");
            ViewBag.AllStatus = new SelectList(DB.Status.Select(s => new { s.StatusID, s.StatusName }), "StatusID", "StatusName");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(WiseSaying wiseSaying)
        {
            if (ModelState.IsValid)
            {
                wiseSaying.WiseSayingDate = DateTime.Now;
                DB.WiseSayings.Add(wiseSaying);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(wiseSaying);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            WiseSaying ws = DB.WiseSayings.Find(id);
            if (ws != null)
            {
                ViewBag.AllElders = new SelectList(DB.Elders.Select(e => new { e.EldersID, e.EldersName }), "EldersID", "EldersName");
                ViewBag.AllStatus = new SelectList(DB.Status.Select(s => new { s.StatusID, s.StatusName }), "StatusID", "StatusName");
                return PartialView(ws);
            }
            TempData["msg"] = "خطأ فى كود المقولة";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(WiseSaying wiseSaying)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(wiseSaying).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(wiseSaying);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            WiseSaying ws = DB.WiseSayings.Find(id);
            if (ws != null)
            {
                DB.WiseSayings.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ فى كود المقولة";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            WiseSaying ws = DB.WiseSayings.Find(id);
            if (ws != null)
            {
                return PartialView(ws);
            }
            TempData["msg"] = "خطأ فى كود المقولة";
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
