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
    public class YearlyValueTradedController : Controller
    {

        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "القيمة المتداولة السنوية";
            var model = DB.YearlyValueTradeds.ToList().ToPagedList(page ?? 1, 10);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
            ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(YearlyValueTraded YearlyValueTraded)
        {
            if (ModelState.IsValid)
            {

                DB.YearlyValueTradeds.Add(YearlyValueTraded);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(YearlyValueTraded);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            YearlyValueTraded ws = DB.YearlyValueTradeds.FirstOrDefault(x => x.ValueTradedId == id);
            if (ws != null)
            {
                ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
                ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(YearlyValueTraded YearlyValueTraded)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(YearlyValueTraded).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(YearlyValueTraded);
        }

        [HttpGet]
        public ActionResult Delete(int id, int yearID)
        {
            YearlyValueTraded ws = DB.YearlyValueTradeds.FirstOrDefault(x => x.ValueTradedId == id);


            if (ws != null)
            {
                DB.YearlyValueTradeds.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
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
