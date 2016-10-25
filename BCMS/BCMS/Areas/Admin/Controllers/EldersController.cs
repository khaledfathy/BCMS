using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using PagedList;
using PagedList.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BCMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EldersController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "المؤلفون";
            var model = DB.Elders.ToList().ToPagedList(page ?? 1, 10);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Elder elder)
        {
            if (ModelState.IsValid)
            {
                DB.Elders.Add(elder);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(elder);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Elder elder = DB.Elders.Find(id);
            if (elder != null)
            {
                return PartialView(elder);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Elder elder)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(elder).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(elder);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Elder elder = DB.Elders.Find(id);
            if (elder != null)
            {
                DB.Elders.Remove(elder);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Elder elder = DB.Elders.Find(id);
            if (elder != null)
            {
                return PartialView(elder);
            }
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
