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

namespace WebTest1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MiseryIndexsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

            Session["PageTitle"] = "مؤشر البؤس ";

            if (id != 0)
            {
                var model = DB.MiseryIndexes.Where(s => s.MarketID == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.MiseryIndexes.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
            ViewBag.AllYears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(MiseryIndex MiseryIndex)
        {
            if (ModelState.IsValid)
            {

                DB.MiseryIndexes.Add(MiseryIndex);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MiseryIndex);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MiseryIndex ws = DB.MiseryIndexes.FirstOrDefault(x => x.MiseryId== id);
            if (ws != null)
            {
                ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
                ViewBag.AllYears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(MiseryIndex MiseryIndex)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(MiseryIndex).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MiseryIndex);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            MiseryIndex ws = DB.MiseryIndexes.FirstOrDefault(x =>x.MiseryId == id);


            if (ws != null)
            {
                DB.MiseryIndexes.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            MiseryIndex ws = DB.MiseryIndexes.FirstOrDefault(x => x.MiseryId == id);

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
