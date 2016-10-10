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
    public class QuarterMarketValuesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = " ربع القيمة السوقية ";
            var model = DB.QuarterMarketValues.ToList().ToPagedList(page ?? 1, 15);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(QuarterMarketValue QuarterMarketValue)
        {
            if (ModelState.IsValid)
            {

                DB.QuarterMarketValues.Add(QuarterMarketValue);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(QuarterMarketValue);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            QuarterMarketValue ws = DB.QuarterMarketValues.FirstOrDefault(x => x.MarketValueId == id);
            if (ws != null)
            {
                ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(QuarterMarketValue QuarterMarketValue)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(QuarterMarketValue).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(QuarterMarketValue);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            QuarterMarketValue ws = DB.QuarterMarketValues.FirstOrDefault(x => x.MarketValueId == id);


            if (ws != null)
            {
                DB.QuarterMarketValues.Remove(ws);
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
            QuarterMarketValue ws = DB.QuarterMarketValues.FirstOrDefault(x => x.MarketValueId == id);

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
