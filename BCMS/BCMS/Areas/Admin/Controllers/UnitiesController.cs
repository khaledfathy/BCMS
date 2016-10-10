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
    public class UnitiesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الوحدة";
            return View(DB.Unities.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Unity Unity)
        {
            if (ModelState.IsValid)
            {
                DB.Unities.Add(Unity);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Unity);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Unity Unity = await DB.Unities.FindAsync(id);
            if (Unity == null)
            {
                return HttpNotFound();
            }
            return PartialView(Unity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Unity Unity)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Unity).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Unity);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Unity Unity = await DB.Unities.FindAsync(id);
            DB.Unities.Remove(Unity);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Unity Unity = await DB.Unities.FindAsync(id);
            if (Unity == null)
            {
                return HttpNotFound();
            }
            return PartialView(Unity);
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