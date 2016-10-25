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
    public class SectorsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "القطاعات";
            return View(DB.Sectors.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sector sector)
        {
            if (ModelState.IsValid)
            {
                DB.Sectors.Add(sector);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(sector);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id=0)
        {
            Sector sector = await DB.Sectors.FindAsync(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return PartialView(sector);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Sector sector)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(sector).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(sector);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id=0)
        {
            Sector sector = await DB.Sectors.FindAsync(id);
            DB.Sectors.Remove(sector);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id=0)
        {
            Sector sector = await DB.Sectors.FindAsync(id);
            if (sector == null)
            {
                return HttpNotFound();
            }
            return PartialView(sector);
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
