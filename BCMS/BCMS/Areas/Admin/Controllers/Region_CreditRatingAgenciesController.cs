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
    public class Region_CreditRatingAgenciesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllRegion = new SelectList(DB.Regions.Select(e => new { e.RegionId, e.RegionArName }), "RegionId", "RegionArName");

            Session["PageTitle"] = "وكالة التصنيف الائتماني لكل منطقة";

            if (id != 0)
            {
                var model = DB.Region_CreditRatingAgency.Where(s => s.RegionId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.Region_CreditRatingAgency.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllRegion = new SelectList(DB.Regions.Select(e => new { e.RegionId, e.RegionArName }), "RegionId", "RegionArName");
            ViewBag.AllAgency = new SelectList(DB.CridetRatingAgencies.Select(e => new { e.AgencyId, e.AgencyArName }), "AgencyId", "AgencyArName");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Region_CreditRatingAgency Region_CreditRatingAgency)
        {
            if (ModelState.IsValid)
            {

                DB.Region_CreditRatingAgency.Add(Region_CreditRatingAgency);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Region_CreditRatingAgency);
        }

        [HttpGet]
        public ActionResult Edit(int id, int AgencyId)
        {
            Region_CreditRatingAgency ws = DB.Region_CreditRatingAgency.FirstOrDefault(x => x.RegionId == id && x.AgencyId == AgencyId);
            if (ws != null)
            {
                ViewBag.AllRegion = new SelectList(DB.Regions.Select(e => new { e.RegionId, e.RegionArName }), "RegionId", "RegionArName");
                ViewBag.AllAgency = new SelectList(DB.CridetRatingAgencies.Select(e => new { e.AgencyId, e.AgencyArName }), "AgencyId", "AgencyArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Region_CreditRatingAgency Region_CreditRatingAgency)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Region_CreditRatingAgency).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Region_CreditRatingAgency);
        }

        [HttpGet]
        public ActionResult Delete(int id, int AgencyId)
        {
            Region_CreditRatingAgency ws = DB.Region_CreditRatingAgency.FirstOrDefault(x => x.RegionId == id && x.AgencyId == AgencyId);


            if (ws != null)
            {
                DB.Region_CreditRatingAgency.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id, int AgencyId)
        {
            Region_CreditRatingAgency ws = DB.Region_CreditRatingAgency.FirstOrDefault(x => x.RegionId == id && x.AgencyId == AgencyId);
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
