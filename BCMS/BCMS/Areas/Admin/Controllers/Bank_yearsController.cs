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
    public class Bank_yearsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page,int id=0)
        {
            ViewBag.AllBank = new SelectList(DB.Banks.Select(e => new { e.BankId, e.BankArName }), "BankId", "BankArName");
            Session["PageTitle"] = "بنوك/سنوات";

            if (id != 0)
            {
                var model = DB.Bank_Year.Where(s => s.BankId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.Bank_Year.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
        }
             [HttpGet]
        public ActionResult search(int? page,int id=0)
        {
            ViewBag.AllBank = new SelectList(DB.Banks.Select(e => new { e.BankId, e.BankArName }), "BankId", "BankArName");
            Session["PageTitle"] = "بنوك/سنوات";
           
            if (id != 0)
            {
                var model = DB.Bank_Year.Where(s => s.BankId == id).ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
            else
            {
                var model = DB.Bank_Year.ToList().ToPagedList(page ?? 1, 10);
                return View(model);
            }
         

           
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AllBank = new SelectList(DB.Banks.Select(e => new { e.BankId, e.BankArName }), "BankId", "BankArName");
            ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Bank_Year Bank_Year)
        {
            if (ModelState.IsValid)
            {

                DB.Bank_Year.Add(Bank_Year);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Bank_Year);
        }

        [HttpGet]
        public ActionResult Edit(int id, int yearID)
        {
            Bank_Year ws = DB.Bank_Year.FirstOrDefault(x => x.BankId == id && x.YearId == yearID);
            if (ws != null)
            {
                ViewBag.AllBank = new SelectList(DB.Banks.Select(e => new { e.BankId, e.BankArName }), "BankId", "BankArName");
                ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");

                return PartialView(ws);
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Bank_Year Bank_Year)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Bank_Year).State = EntityState.Modified;
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Bank_Year);
        }

        [HttpGet]
        public ActionResult Delete(int id, int yearID)
        {
            Bank_Year ws = DB.Bank_Year.FirstOrDefault(x => x.BankId == id && x.YearId == yearID);


            if (ws != null)
            {
                DB.Bank_Year.Remove(ws);
                DB.SaveChanges();
                TempData["msg"] = "تمت عملية الحذف بنجاح";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "خطأ ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id, int yearID)
        {
            Bank_Year ws = DB.Bank_Year.FirstOrDefault(x => x.BankId == id && x.YearId == yearID);

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
