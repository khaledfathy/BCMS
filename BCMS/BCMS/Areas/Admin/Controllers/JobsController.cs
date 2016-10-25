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
    public class JobsController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الوظائف";
            return View(DB.Jobs.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(from s in DB.Status select new { s.StatusID, s.StatusName }, "StatusID", "StatusName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Job job)
        {
            if (ModelState.IsValid)
            {
                DB.Jobs.Add(job);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تم إضافة وظيفة جديدة";
                return RedirectToAction("Index");
            }
            return PartialView(job);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Job job = await DB.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(from s in DB.Status select new { s.StatusID, s.StatusName }, "StatusID", "StatusName");
            return PartialView(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(job).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(job);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id = 0)
        {
            Job job = await DB.Jobs.FindAsync(id);
            DB.Jobs.Remove(job);
            await DB.SaveChangesAsync();
            TempData["msg"] = "تم حذف الوظيفة بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Job job = await DB.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.Specification = DB.Job_Specification.Where(s => s.JobID == id).ToList();
            ViewBag.Education = DB.Job_Education.Where(s => s.JobID == id).ToList();
            ViewBag.Prefer = DB.Job_Prefer.Where(s => s.JobID == id).ToList();
            ViewBag.Skill = DB.Job_Skill.Where(s => s.JobID == id).ToList();
            return PartialView(job);
        }

        //====================Specification==============================

        [HttpGet]
        public ActionResult CreateSpecification(int id = 0)
        {
            ViewBag.CurrentID = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateSpecification(FormCollection Specification)
        {
            Job_Specification JS = new Job_Specification();
            JS.JobID = Convert.ToInt32(Specification["JobID"]);
            JS.specification = Specification["specification"];

            DB.Job_Specification.Add(JS);
            DB.SaveChanges();
            TempData["NewMsg"] = "تم إضافة وصف جديد .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSpecification(int id = 0)
        {
            //ViewBag.CurrentID = id;
            Job_Specification job_Specification = DB.Job_Specification.Find(id);
            if (job_Specification == null)
            {
                return HttpNotFound();
            }
            ViewBag.JSID = job_Specification.JSID;
            ViewBag.JobID = job_Specification.JobID;
            ViewBag.Specification = job_Specification.specification;
            return PartialView();
        }

        [HttpPost]
        public ActionResult EditSpecification(FormCollection Specification)
        {
            Job_Specification JS = new Job_Specification();
            JS.JSID = Convert.ToInt32(Specification["JSID"]);
            JS.JobID = Convert.ToInt32(Specification["JobID"]);
            JS.specification = Specification["specification"];
            DB.Entry(JS).State = EntityState.Modified;
            DB.SaveChanges();
            TempData["NewMsg"] = "تم تعديل الوصف .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteSpecification(int id = 0)
        {
            Job_Specification job = DB.Job_Specification.Find(id);
            DB.Job_Specification.Remove(job);
            DB.SaveChanges();
            TempData["NewMsg"] = "تمت عملية الحذف";
            return RedirectToAction("Index");
        }

        //======================Skill============================

        [HttpGet]
        public ActionResult CreateSkill(int id = 0)
        {
            ViewBag.CurrentID = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateSkill(FormCollection skill)
        {
            Job_Skill JS = new Job_Skill();
            JS.JobID = Convert.ToInt32(skill["JobID"]);
            JS.Skill = skill["Skill"];
            if (ModelState.IsValid)
            {
                DB.Job_Skill.Add(JS);
                DB.SaveChanges();
                TempData["NewMsg"] = "تم إضافة مهاره جديد .";
                return RedirectToAction("Index");
            }
            return PartialView(JS);
        }

        [HttpGet]
        public ActionResult EditSkill(int id = 0)
        {
            //ViewBag.CurrentID = id;
            Job_Skill job_Skill = DB.Job_Skill.Find(id);
            if (job_Skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobSkillID = job_Skill.JobSkillID;
            ViewBag.JobID = job_Skill.JobID;
            ViewBag.Skill = job_Skill.Skill;
            return PartialView();
        }

        [HttpPost]
        public ActionResult EditSkill(FormCollection Specification)
        {
            Job_Skill JS = new Job_Skill();
            JS.JobSkillID = Convert.ToInt32(Specification["JobSkillID"]);
            JS.JobID = Convert.ToInt32(Specification["JobID"]);
            JS.Skill = Specification["Skill"];

            DB.Entry(JS).State = EntityState.Modified;
            DB.SaveChanges();
            TempData["NewMsg"] = "تم تعديل المهارات .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteSkill(int id = 0)
        {
            Job_Skill job = DB.Job_Skill.Find(id);
            DB.Job_Skill.Remove(job);
            DB.SaveChanges();
            TempData["NewMsg"] = "تمت عملية الحذف";
            return RedirectToAction("Index");
        }

        //===================Education===============================

        [HttpGet]
        public ActionResult CreateEducation(int id = 0)
        {
            ViewBag.CurrentID = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateEducation(FormCollection skill)
        {
            Job_Education JE = new Job_Education();
            JE.JobID = Convert.ToInt32(skill["JobID"]);
            JE.Education = skill["Education"];
            if (ModelState.IsValid)
            {
                DB.Job_Education.Add(JE);
                DB.SaveChanges();
                TempData["NewMsg"] = "تم إضافة شهاده جديدة .";
                return RedirectToAction("Index");
            }
            return PartialView(JE);
        }

        [HttpGet]
        public ActionResult EditEducation(int id = 0)
        {
            //ViewBag.CurrentID = id;
            Job_Education job_Education = DB.Job_Education.Find(id);
            if (job_Education == null)
            {
                return HttpNotFound();
            }
            ViewBag.JEID = job_Education.JEID;
            ViewBag.JobID = job_Education.JobID;
            ViewBag.Education = job_Education.Education;
            return PartialView();
        }

        [HttpPost]
        public ActionResult EditEducation(FormCollection Specification)
        {
            Job_Education JE = new Job_Education();
            JE.JEID = Convert.ToInt32(Specification["JEID"]);
            JE.JobID = Convert.ToInt32(Specification["JobID"]);
            JE.Education = Specification["Education"];

            DB.Entry(JE).State = EntityState.Modified;
            DB.SaveChanges();
            TempData["NewMsg"] = "تم تعديل الشهادات الدراسية .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEducation(int id = 0)
        {
            Job_Education job = DB.Job_Education.Find(id);
            DB.Job_Education.Remove(job);
            DB.SaveChanges();
            TempData["NewMsg"] = "تمت عملية الحذف";
            return RedirectToAction("Index");
        }

        //=====================Prefer=============================

        [HttpGet]
        public ActionResult CreatePrefer(int id = 0)
        {
            ViewBag.CurrentID = id;
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreatePrefer(FormCollection skill)
        {
            Job_Prefer JP = new Job_Prefer();
            JP.JobID = Convert.ToInt32(skill["JobID"]);
            JP.Prefer = skill["Prefer"];
            if (ModelState.IsValid)
            {
                DB.Job_Prefer.Add(JP);
                DB.SaveChanges();
                TempData["NewMsg"] = "تم إضافة تفضيل جديد .";
                return RedirectToAction("Index");
            }
            return PartialView(JP);
        }

        [HttpGet]
        public ActionResult EditPrefer(int id = 0)
        {
            //ViewBag.CurrentID = id;
            Job_Prefer job_Prefer = DB.Job_Prefer.Find(id);
            if (job_Prefer == null)
            {
                return HttpNotFound();
            }
            ViewBag.JPID = job_Prefer.JPID;
            ViewBag.JobID = job_Prefer.JobID;
            ViewBag.Prefer = job_Prefer.Prefer;
            return PartialView();
        }

        [HttpPost]
        public ActionResult EditPrefer(FormCollection Specification)
        {
            Job_Prefer JP = new Job_Prefer();
            JP.JPID = Convert.ToInt32(Specification["JPID"]);
            JP.JobID = Convert.ToInt32(Specification["JobID"]);
            JP.Prefer = Specification["Prefer"];

            DB.Entry(JP).State = EntityState.Modified;
            DB.SaveChanges();
            TempData["NewMsg"] = "تم تعديل التفضيلات .";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeletePrefer(int id = 0)
        {
            Job_Prefer job = DB.Job_Prefer.Find(id);
            DB.Job_Prefer.Remove(job);
            DB.SaveChanges();
            TempData["NewMsg"] = "تمت عملية الحذف";
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
