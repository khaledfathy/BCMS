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
    public class subjectController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "المواضيع";
            return View(DB.subjects.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(subject subject)
        {
            if (ModelState.IsValid)
            {
                DB.subjects.Add(subject);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(subject);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            subject subject = await DB.subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return PartialView(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(subject subject)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(subject).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(subject);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            subject subject = await DB.subjects.FindAsync(id);
            DB.subjects.Remove(subject);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            subject subject = await DB.subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return PartialView(subject);
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
