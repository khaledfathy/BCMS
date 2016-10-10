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
    public class RelaxationVideoController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        // GET: /Admin/Activities/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "فيديوهات الإسترخاء";
            return View(DB.RelaxationVideos.ToList().ToPagedList(page ?? 1, 5));
        }


        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RelaxationVideo RelaxationVideo)
        {
            if (ModelState.IsValid)
            {
                DB.RelaxationVideos.Add(RelaxationVideo);
                await DB.SaveChangesAsync();
                TempData["msg"] = "تمت عملية الاضافة بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(RelaxationVideo);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            RelaxationVideo RelaxationVideo = await DB.RelaxationVideos.FindAsync(id);
            if (RelaxationVideo == null)
            {
                return HttpNotFound();
            }
            return PartialView(RelaxationVideo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RelaxationVideo RelaxationVideo)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(RelaxationVideo).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تم التعديل بنجاح";
                return RedirectToAction("Index");
            }
            return PartialView(RelaxationVideo);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            RelaxationVideo RelaxationVideo = await DB.RelaxationVideos.FindAsync(id);
            DB.RelaxationVideos.Remove(RelaxationVideo);
            await DB.SaveChangesAsync();
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
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
