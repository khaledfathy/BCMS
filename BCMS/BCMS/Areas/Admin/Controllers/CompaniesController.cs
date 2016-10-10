using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace WebTest1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllSector = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");

            Session["PageTitle"] = "الشركات";

            if (id != 0)
            {
                var model = DB.CompanyInfoes.Where(s => s.SectorID == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.CompanyInfoes.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllSectors = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                companyInfo.CompanyInfoDate = DateTime.Now;
                DB.CompanyInfoes.Add(companyInfo);
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم إضافة شركة جديدة";
                return RedirectToAction("Index");
            }
            return PartialView(companyInfo);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            ViewBag.AllSectors = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");
            CompanyInfo companyInfo = await DB.CompanyInfoes.FindAsync(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return PartialView(companyInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                companyInfo.CompanyInfoDate = DateTime.Now;
                DB.Entry(companyInfo).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(companyInfo);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            CompanyInfo companyInfo = await DB.CompanyInfoes.FindAsync(id);
            DB.CompanyInfoes.Remove(companyInfo);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            CompanyInfo companyInfo = await DB.CompanyInfoes.FindAsync(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return PartialView(companyInfo);
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
