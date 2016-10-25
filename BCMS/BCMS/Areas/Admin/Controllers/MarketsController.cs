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
    public class MarketsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الأسواق";
            return View(DB.Markets.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllType = new SelectList(DB.MarketTypes.Select(e => new { e.MarketTypeId, e.MarketTypeArName }), "MarketTypeId", "MarketTypeArName");

            ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Market Market)
        {
            if (ModelState.IsValid)
            {
                DB.Markets.Add(Market);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Market);
        }

        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            Market ws = DB.Markets.FirstOrDefault(x => x.MarketId == id);
            if (ws != null)
            {
                ViewBag.AllType = new SelectList(DB.MarketTypes.Select(e => new { e.MarketTypeId, e.MarketTypeArName }), "MarketTypeId", "MarketTypeArName");
                ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Market Market)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Market).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Market);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Market Market = await DB.Markets.FindAsync(id);
            DB.Markets.Remove(Market);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Market Market = await DB.Markets.FindAsync(id);
            if (Market == null)
            {
                return HttpNotFound();
            }
            return PartialView(Market);
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
