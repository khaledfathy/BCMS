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
    public class RelativeSizeController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الحجم النسبي";
            return View(DB.RelativeSizes.ToList().ToPagedList(page ?? 1, 15));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RelativeSize RelativeSize)
        {
            if (ModelState.IsValid)
            {
                DB.RelativeSizes.Add(RelativeSize);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(RelativeSize);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            RelativeSize RelativeSize = await DB.RelativeSizes.FindAsync(id);
            if (RelativeSize == null)
            {
                return HttpNotFound();
            }
            return PartialView(RelativeSize);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RelativeSize RelativeSize)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(RelativeSize).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(RelativeSize);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            RelativeSize RelativeSize = await DB.RelativeSizes.FindAsync(id);
            DB.RelativeSizes.Remove(RelativeSize);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            RelativeSize RelativeSize = await DB.RelativeSizes.FindAsync(id);
            if (RelativeSize == null)
            {
                return HttpNotFound();
            }
            return PartialView(RelativeSize);
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
