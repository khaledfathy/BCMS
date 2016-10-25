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
    public class MarketValuesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

            Session["PageTitle"] = "القيمة السوقية ";

            if (id != 0)
            {
                var model = DB.MarketValues.Where(s => s.MarketId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.MarketValues.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(MarketValue MarketValue)
        {
            if (ModelState.IsValid)
            {

                DB.MarketValues.Add(MarketValue);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MarketValue);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MarketValue ws = DB.MarketValues.FirstOrDefault(x => x.MarketValueId == id);
            if (ws != null)
            {
                ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(MarketValue MarketValue)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(MarketValue).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MarketValue);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            MarketValue ws = DB.MarketValues.FirstOrDefault(x => x.MarketValueId == id);


            if (ws != null)
            {
                DB.MarketValues.Remove(ws);
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
            MarketValue ws = DB.MarketValues.FirstOrDefault(x => x.MarketValueId == id);

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
