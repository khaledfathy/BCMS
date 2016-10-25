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
    public class KnowledgeController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "وسع ثقتك";
            return View(DB.Knowledges.ToList().ToPagedList(page ?? 1, 10));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(from s in DB.Status select new { s.StatusID, s.StatusName }, "StatusID", "StatusName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Knowledge know)
        {
            if (ModelState.IsValid)
            {
                DB.Knowledges.Add(know);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تم إضافة تخصص جديد";
                return RedirectToAction("Index");
            }
            return PartialView(know);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Knowledge know = await DB.Knowledges.FindAsync(id);
            if (know == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(from s in DB.Status select new { s.StatusID, s.StatusName }, "StatusID", "StatusName");
            return PartialView(know);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Knowledge know)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(know).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(know);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id = 0)
        {
            Knowledge know = await DB.Knowledges.FindAsync(id);
            DB.Knowledges.Remove(know);
            await DB.SaveChangesAsync();
            TempData["msg"] = "تم الحذف  بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Knowledge know = await DB.Knowledges.FindAsync(id);
            if (know == null)
            {
                return HttpNotFound();
            }
            ViewBag.Information = DB.Information.Where(s => s.KnowledgeID == id).ToList();
            return PartialView(know);
        }
       // -----------------------------Informations-----------------------

        [HttpGet]
        public ActionResult CreateInformation(int id = 0)
        {
            ViewBag.CurrentID = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateInformation(FormCollection Information )
        {
            Information info = new Information();
            info.KnowledgeID = Convert.ToInt32(Information["KnowledgeID"]);
            info.InformationTitle = Information["InformationTitle"];

            DB.Information.Add(info);
            DB.SaveChanges();
            TempData["NewMsg"] = "تم إضافة معلومة جديدة .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editinformation(int id = 0)
        {
            ViewBag.CurrentID = id;
            Information information = DB.Information.Find(id);
            if (information == null)
            {
                return HttpNotFound();
            }
            ViewBag.infoID = information.InformationID;
            ViewBag.knowID = information.KnowledgeID;
            ViewBag.informationTitle = information.InformationTitle;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Editinformation(FormCollection Information)
        {
            
            Information info = new Information();
            info.InformationID = Convert.ToInt32(Information["InformationID"]);
            info.KnowledgeID = Convert.ToInt32(Information["KnowledgeID"]);
            info.InformationTitle = Information["InformationTitle"];
            DB.Entry(info).State = EntityState.Modified;
            DB.SaveChanges();
            TempData["NewMsg"] = "تم تعديل المعلومة .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Deleteinformation(int id = 0)
        {
            Information info = DB.Information.Find(id);
            DB.Information.Remove(info);
            DB.SaveChanges();
            TempData["NewMsg"] = "تمت عملية الحذف";
            return RedirectToAction("Index");
        }

	}
}