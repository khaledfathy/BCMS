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
    public class Country_CreditRatingAgenciesController : Controller
    {

        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllCountry = new SelectList(DB.Countries.Where(e =>e.State ==true).Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");

            Session["PageTitle"] = "وكالة التصنيف الائتماني لكل دولة";
            if (id != 0)
            {
                var model = DB.Country_CreditRatingAgency.Where(s => s.CountryId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.Country_CreditRatingAgency.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");
            ViewBag.AllAgency = new SelectList(DB.CridetRatingAgencies.Select(e => new { e.AgencyId, e.AgencyArName }), "AgencyId", "AgencyArName");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Country_CreditRatingAgency Country_CreditRatingAgency)
        {
            if (ModelState.IsValid)
            {

                DB.Country_CreditRatingAgency.Add(Country_CreditRatingAgency);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Country_CreditRatingAgency);
        }

        [HttpGet]
        public ActionResult Edit(int id,int AgencyId)
        {
            Country_CreditRatingAgency ws = DB.Country_CreditRatingAgency.FirstOrDefault(x => x.CountryId == id &&x.AgencyId==AgencyId);
            if (ws != null)
            {
                ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");
                ViewBag.AllAgency = new SelectList(DB.CridetRatingAgencies.Select(e => new { e.AgencyId, e.AgencyArName }), "AgencyId", "AgencyArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Country_CreditRatingAgency Country_CreditRatingAgency)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Country_CreditRatingAgency).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Country_CreditRatingAgency);
        }

        [HttpGet]
        public ActionResult Delete(int id, int AgencyId)
        {
            Country_CreditRatingAgency ws = DB.Country_CreditRatingAgency.FirstOrDefault(x => x.CountryId == id && x.AgencyId == AgencyId);


            if (ws != null)
            {
                DB.Country_CreditRatingAgency.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id, int AgencyId)
        {
            Country_CreditRatingAgency ws = DB.Country_CreditRatingAgency.FirstOrDefault(x => x.CountryId == id && x.AgencyId == AgencyId);
            if (ws != null)
            {
                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
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
