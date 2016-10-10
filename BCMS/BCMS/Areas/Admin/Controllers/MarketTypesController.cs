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
    public class MarketTypesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "أنواع الأسواق";
            return View(DB.MarketTypes.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MarketType MarketType)
        {
            if (ModelState.IsValid)
            {
                DB.MarketTypes.Add(MarketType);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MarketType);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            MarketType MarketType = await DB.MarketTypes.FindAsync(id);
            if (MarketType == null)
            {
                return HttpNotFound();
            }
            return PartialView(MarketType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MarketType MarketType)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(MarketType).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(MarketType);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            MarketType MarketType = await DB.MarketTypes.FindAsync(id);
            DB.MarketTypes.Remove(MarketType);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            MarketType MarketType = await DB.MarketTypes.FindAsync(id);
            if (MarketType == null)
            {
                return HttpNotFound();
            }
            return PartialView(MarketType);
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
