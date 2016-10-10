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
    public class FaqsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الاسئلة المتكررة";
            return View(DB.Faqs.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "FaqID")]Faq faq)
        {
            if (ModelState.IsValid)
            {
                DB.Faqs.Add(faq);
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(faq);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Faq faq = await DB.Faqs.FindAsync(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return PartialView(faq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Faq faq)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(faq).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(faq);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Faq faq = await DB.Faqs.FindAsync(id);
            DB.Faqs.Remove(faq);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Faq faq = await DB.Faqs.FindAsync(id);
            if (faq == null)
            {
                return HttpNotFound();
            }
            return PartialView(faq);
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
