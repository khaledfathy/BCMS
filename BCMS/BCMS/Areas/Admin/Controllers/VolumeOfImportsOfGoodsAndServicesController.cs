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
    public class VolumeOfImportsOfGoodsAndServicesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page, int id = 0)
        {
            ViewBag.AllCountry = new SelectList(DB.Countries.Where(e => e.State == true).Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");

            Session["PageTitle"] = "حجم الوادات من  السلع والخدمات";

            if (id != 0)
            {
                var model = DB.VolumeOfImportsOfGoodsAndServices.Where(s => s.CountryId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.VolumeOfImportsOfGoodsAndServices.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllYear = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
            ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");
            ViewBag.AllSubject = new SelectList(DB.subjects.Select(e => new { e.SubjectId, e.subject1 }), "SubjectId", "subject1");
            ViewBag.AllUnity = new SelectList(DB.Unities.Select(e => new { e.UnityID, e.Unity1 }), "UnityID", "Unity1");

            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(VolumeOfImportsOfGoodsAndService v)
        {
            if (ModelState.IsValid)
            {

                DB.VolumeOfImportsOfGoodsAndServices.Add(v);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(v);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            VolumeOfImportsOfGoodsAndService ws = DB.VolumeOfImportsOfGoodsAndServices.FirstOrDefault(x => x.ImportOfGoodsServicesID == id);
            if (ws != null)
            {
                ViewBag.AllYear = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
                ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryId, e.CountryArName }), "CountryId", "CountryArName");
                ViewBag.AllSubject = new SelectList(DB.subjects.Select(e => new { e.SubjectId, e.subject1 }), "SubjectId", "subject1");
                ViewBag.AllUnity = new SelectList(DB.Unities.Select(e => new { e.UnityID, e.Unity1 }), "UnityID", "Unity1");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(VolumeOfExportsOfGoodsAndService v)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(v).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(v);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            VolumeOfImportsOfGoodsAndService ws = DB.VolumeOfImportsOfGoodsAndServices.FirstOrDefault(x => x.ImportOfGoodsServicesID == id);


            if (ws != null)
            {
                DB.VolumeOfImportsOfGoodsAndServices.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            VolumeOfImportsOfGoodsAndService ws = DB.VolumeOfImportsOfGoodsAndServices.FirstOrDefault(x => x.ImportOfGoodsServicesID == id);

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
