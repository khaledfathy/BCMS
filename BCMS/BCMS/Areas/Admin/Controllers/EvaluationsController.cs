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
    public class EvaluationsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "التقييم";
            var model = DB.Evaluations.ToList().ToPagedList(page ?? 1, 10);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllAgency = new SelectList(DB.CridetRatingAgencies.Select(e => new { e.AgencyId, e.AgencyArName }), "AgencyId", "AgencyArName");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Evaluation Evaluation)
        {
            if (ModelState.IsValid)
            {

                DB.Evaluations.Add(Evaluation);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Evaluation);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Evaluation ws = DB.Evaluations.FirstOrDefault(x => x.EvaluationId== id );
            if (ws != null)
            {
                ViewBag.AllAgency = new SelectList(DB.CridetRatingAgencies.Select(e => new { e.AgencyId, e.AgencyArName }), "AgencyId", "AgencyArName");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Evaluation Evaluation)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Evaluation).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Evaluation);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Evaluation ws = DB.Evaluations.FirstOrDefault(x => x.EvaluationId == id);


            if (ws != null)
            {
                DB.Evaluations.Remove(ws);
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
            Evaluation ws = DB.Evaluations.FirstOrDefault(x => x.EvaluationId == id);

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
