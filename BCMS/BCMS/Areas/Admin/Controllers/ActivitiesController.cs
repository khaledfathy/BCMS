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
    public class ActivitiesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الأنشطة";
            return View(DB.Activities.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                DB.Activities.Add(activity);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(activity);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Activity activity = await DB.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return PartialView(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(activity).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(activity);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Activity activity = await DB.Activities.FindAsync(id);
            DB.Activities.Remove(activity);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Activity activity = await DB.Activities.FindAsync(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return PartialView(activity);
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
