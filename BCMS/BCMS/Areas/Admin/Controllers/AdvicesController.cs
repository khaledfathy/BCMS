using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using PagedList;
using PagedList.Mvc;

namespace WebTest1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdvicesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "نصائح استثمارية";
            return View(DB.Advices.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "AdviceID")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                DB.Advices.Add(advice);
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم إضافة  نصيحة جديدة";
                return RedirectToAction("Index");
            }

            return PartialView(advice);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Advice advice = await DB.Advices.FindAsync(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return PartialView(advice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Advice advice)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(advice).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(advice);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Advice advice = await DB.Advices.FindAsync(id);
            DB.Advices.Remove(advice);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Advice advice = await DB.Advices.FindAsync(id);
            if (advice == null)
            {
                return HttpNotFound();
            }
            return PartialView(advice);
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
