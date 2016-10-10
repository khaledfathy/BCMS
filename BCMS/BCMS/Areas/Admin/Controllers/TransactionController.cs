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
    public class TransactionController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "العمليات";
            return View(DB.Transactions.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllSectors = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Transaction Transaction)
        {
            if (ModelState.IsValid)
            {
                DB.Transactions.Add(Transaction);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Transaction);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Transaction ws = DB.Transactions.FirstOrDefault(x => x.TransactionId == id);
            if (ws != null)
            {
                ViewBag.AllSectors = new SelectList(DB.Sectors.Select(e => new { e.RecordID, e.SectorName }), "RecordID", "SectorName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Transaction Transaction)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Transaction).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Transaction);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Transaction Transaction = await DB.Transactions.FindAsync(id);
            DB.Transactions.Remove(Transaction);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Transaction Transaction = await DB.Transactions.FindAsync(id);
            if (Transaction == null)
            {
                return HttpNotFound();
            }
            return PartialView(Transaction);
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
