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
    public class CridetRatingAgenciesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "وكالة التصنيف الائتماني";
            return View(DB.CridetRatingAgencies.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CridetRatingAgency CridetRatingAgency)
        {
            if (ModelState.IsValid)
            {
                DB.CridetRatingAgencies.Add(CridetRatingAgency);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(CridetRatingAgency);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            CridetRatingAgency CridetRatingAgency = await DB.CridetRatingAgencies.FindAsync(id);
            if (CridetRatingAgency == null)
            {
                return HttpNotFound();
            }
            return PartialView(CridetRatingAgency);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CridetRatingAgency CridetRatingAgency)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(CridetRatingAgency).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(CridetRatingAgency);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            CridetRatingAgency CridetRatingAgency = await DB.CridetRatingAgencies.FindAsync(id);
            DB.CridetRatingAgencies.Remove(CridetRatingAgency);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            CridetRatingAgency CridetRatingAgency = await DB.CridetRatingAgencies.FindAsync(id);
            if (CridetRatingAgency == null)
            {
                return HttpNotFound();
            }
            return PartialView(CridetRatingAgency);
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
