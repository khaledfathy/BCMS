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
    public class BanksController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "البنوك";
            return View(DB.Banks.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Bank bank)
        {
            if (ModelState.IsValid)
            {
                DB.Banks.Add(bank);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(bank);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Bank bank = await DB.Banks.FindAsync(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return PartialView(bank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Bank bank)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(bank).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(bank);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Bank bank = await DB.Banks.FindAsync(id);
            DB.Banks.Remove(bank);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public async Task<ActionResult> Details(int id)
        //{
        //    Bank ws = DB.Banks.FirstOrDefault(x => x.BankId == id);
        //    if (ws == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.sub = DB.Bank_Year.Where(s => s.BankId == id).ToList();

        //    return PartialView(ws);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
        //===============

        //[HttpGet]
        //public ActionResult CreateBankyear(int id = 0)
        //{
        //    ViewBag.CurrentID = id;
        //    //  ViewBag.AllCountry = new SelectList(DB.Countries.Select(e => new { e.CountryID, e.CountryName }), "CountryID", "CountryName");
        //    ViewBag.Allyears = new SelectList(DB.Years.Select(e => new { e.YearId, e.YearN }), "YearId", "YearN");

        //    return PartialView();
        //}


        //[HttpPost]
        //public ActionResult CreateBankYear(FormCollection BY)
        //{
        //    Bank_Year JS = new Bank_Year();
        //    JS.BankId = Convert.ToInt32(BY["id"]);
        //    JS.YearId =Convert.ToInt16(BY["Year"]);
        //    JS.ATMMachine = Convert.ToInt32(BY["ATM"]);
        //    JS.PercentageGrowthATMMachine = Convert.ToInt16(BY["preGATM"]);
        //    JS.BranchsBank = Convert.ToInt32(BY["BranchsBank"]);
        //    JS.PercentageGrowthBranchsBank = Convert.ToInt32(BY["preGBranchs"]);
        //    DB.Bank_Year.Add(JS);
        //    DB.SaveChanges();
        //    TempData["NewMsg"] = "تم إضافة  .";
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public ActionResult EditBankYear(int id = 0, int year=0)
        //{

        //    Bank_Year by = DB.Bank_Year.FirstOrDefault(x => x.BankId == id&&x.YearId==year);
        //    if (by == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.year = by.BankId;
           
        //    ViewBag.year = by.YearId;
        //    ViewBag.ATM = by.ATMMachine;
        //    ViewBag.branch = by.BranchsBank;
        //    ViewBag.preATM = by.PercentageGrowthATMMachine;
        //    ViewBag.prebransg = by.PercentageGrowthBranchsBank;
        //    return PartialView();
        //}

        //[HttpPost]
        //public ActionResult EditBankYear(FormCollection by)
        //{
        //    Bank_Year JS = new Bank_Year();
        //    JS.BankId = Convert.ToInt32(by["id"]);
        //    JS.YearId = Convert.ToInt32(by["year"]);
        //    JS.ATMMachine = Convert.ToInt32(by["atm"]);
        //    JS.BranchsBank = Convert.ToInt32(by["branch"]);
        //    JS.PercentageGrowthATMMachine = Convert.ToInt32(by["preatm"]);

        //    JS.PercentageGrowthBranchsBank = Convert.ToInt32(by["prebranch"]);
        //    DB.Entry(JS).State = EntityState.Modified;
        //    DB.SaveChanges();
        //    TempData["NewMsg"] = "تم تعديل  .";
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public ActionResult DeleteBankYear(int id = 0)
        //{
        //    Bank_Year ans = DB.Bank_Year.Find(id);
        //    DB.Bank_Year.Remove(ans);
        //    DB.SaveChanges();
        //    TempData["NewMsg"] = "تمت عملية الحذف";
        //    return RedirectToAction("Index");
        //}
    }
}
