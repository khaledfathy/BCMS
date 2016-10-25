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
    public class MarketAnalysesController : Controller
    {
        //المؤشرات المالية اليومية	

        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
            ViewBag.AllSector = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");
            Session["PageTitle"] = "الأسهم الحرة لقطاعات السوق المالية ";
            if (id != 0)
            {
                var model = DB.MarketAnalyses.Where(s => s.SectorId == id ).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.MarketAnalyses.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllYear = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
            ViewBag.AllSector = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(MarketAnalyse MarketAnalyse)
        {
            if (ModelState.IsValid)
            {

                DB.MarketAnalyses.Add(MarketAnalyse);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MarketAnalyse);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MarketAnalyse ws = DB.MarketAnalyses.FirstOrDefault(x => x.marketAnalysisId == id);
            if (ws != null)
            {
                ViewBag.AllYear = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
                ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
                ViewBag.AllSector = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");
                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(MarketAnalyse MarketAnalyse)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(MarketAnalyse).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MarketAnalyse);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            MarketAnalyse ws = DB.MarketAnalyses.FirstOrDefault(x => x.marketAnalysisId == id);


            if (ws != null)
            {
                DB.MarketAnalyses.Remove(ws);
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
            MarketAnalyse ws = DB.MarketAnalyses.FirstOrDefault(x => x.marketAnalysisId == id);

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
