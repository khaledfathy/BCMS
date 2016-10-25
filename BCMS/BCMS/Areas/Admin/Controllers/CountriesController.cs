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
    public class CountriesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllContinent = new SelectList(DB.Continents.Select(e => new { e.ContinentId, e.ContinentArName }), "ContinentId", "ContinentArName");

            Session["PageTitle"] = "الدول";

            if (id != 0)
            {
                var model = DB.Countries.Where(s => s.ContinentId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.Countries.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "مفعلة", Value = "true" });
            li.Add(new SelectListItem { Text = "غير مفعلة", Value = "false" });
            ViewBag.state= li;
            ViewBag.AllContinent = new SelectList(DB.Continents.Select(e => new { e.ContinentId, e.ContinentArName }), "ContinentId", "ContinentArName");
           // ViewBag.AllStatus = new SelectList(DB.Status.Select(s => new { s.StatusID, s.StatusName }), "StatusID", "StatusName");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Country Country)
        {
            if (ModelState.IsValid)
            {
            //    wiseSaying.WiseSayingDate = DateTime.Now;
                DB.Countries.Add(Country);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Country);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Country ws = DB.Countries.Find(id);
            if (ws != null)
            {
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "مفعلة", Value = "true" });
                li.Add(new SelectListItem { Text = "غير مفعلة", Value = "false" });
                ViewBag.state = li;
                ViewBag.AllContinent = new SelectList(DB.Continents.Select(e => new { e.ContinentId, e.ContinentArName }), "ContinentId", "ContinentArName");
                return PartialView(ws);
            }
            TempData["msg"] = "خطأ فى كود المقولة";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Country Country)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Country).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Country);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Country ws = DB.Countries.Find(id);
            if (ws != null)
            {
                DB.Countries.Remove(ws);
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
            Country ws = DB.Countries.Find(id);
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
