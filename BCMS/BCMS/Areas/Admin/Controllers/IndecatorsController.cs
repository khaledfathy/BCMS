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
    public class IndecatorsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "المؤشرات";
            var model = DB.Indecators.ToList().ToPagedList(page ?? 1, 10);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Indecator Indecator)
        {
            if (ModelState.IsValid)
            {

                DB.Indecators.Add(Indecator);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Indecator);
        }

        [HttpGet]
        public ActionResult Edit(short id)
        {
            Indecator ws = DB.Indecators.FirstOrDefault(x => x.IndecatorId == id);
            if (ws!= null)
            {
                ViewBag.AllMarket = new SelectList(DB.Markets.Select(e => new { e.MarketId, e.MarketArName }), "MarketId", "MarketArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Indecator Indecator)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Indecator).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Indecator);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Indecator ws = DB.Indecators.FirstOrDefault(x => x.IndecatorId == id);


            if (ws != null)
            {
                DB.Indecators.Remove(ws);
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
            Indecator ws = DB.Indecators.FirstOrDefault(x => x.IndecatorId == id);

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
