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
    public class YearsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "السنوات";
            return View(DB.Years.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Year Year)
        {
            if (ModelState.IsValid)
            {
                DB.Years.Add(Year);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Year);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Year Year = await DB.Years.FindAsync(id);
            if (Year == null)
            {
                return HttpNotFound();
            }
            return PartialView(Year);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Year Year)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Year).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Year);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Year Year = await DB.Years.FindAsync(id);
            DB.Years.Remove(Year);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
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
