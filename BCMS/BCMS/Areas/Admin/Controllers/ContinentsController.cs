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
    public class ContinentsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "القارات";
            return View(DB.Continents.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Continent Continent)
        {
            if (ModelState.IsValid)
            {
                DB.Continents.Add(Continent);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Continent);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Continent Continent = await DB.Continents.FindAsync(id);
            if (Continent == null)
            {
                return HttpNotFound();
            }
            return PartialView(Continent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Continent Continent)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(Continent).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(Continent);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Continent Continent = await DB.Continents.FindAsync(id);
            DB.Continents.Remove(Continent);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Continent Continent = await DB.Continents.FindAsync(id);
            if (Continent == null)
            {
                return HttpNotFound();
            }
            return PartialView(Continent);
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
