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
    public class RegionsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "المناطق";
            return View(DB.Regions.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Region Region)
        {
            if (ModelState.IsValid)
            {
                DB.Regions.Add(Region);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Region);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Region Region = await DB.Regions.FindAsync(id);
            if (Region == null)
            {
                return HttpNotFound();
            }
            return PartialView(Region);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Region Region)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Region).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Region);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Region Region = await DB.Regions.FindAsync(id);
            DB.Regions.Remove(Region);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Region Region = await DB.Regions.FindAsync(id);
            if (Region == null)
            {
                return HttpNotFound();
            }
            return PartialView(Region);
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
