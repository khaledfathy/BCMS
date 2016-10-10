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
    public class GamesController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        [HttpGet]
        public ActionResult Index(int? page)
        {
            Session["PageTitle"] = "الألعاب";
            return View(DB.Games.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(from s in DB.Status select new { s.StatusID, s.StatusName }
         , "StatusID", "StatusName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Game game, HttpPostedFileBase file, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                DB.Games.Add(game);
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تمت عملية الاضافة بنجاح";

                if (file.ContentLength > 0)
                {
                    var path = Server.MapPath("~/Images/Games/") + game.GameID + ".jpg";
                    file.SaveAs(path);
                }

                if (file1.ContentLength > 0)
                {
                    var path1 = Server.MapPath("~/Images/Games/") + game.GameID + ".swf";
                    file1.SaveAs(path1);
                }



                return RedirectToAction("Index");
            }
            return PartialView(game);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            Game game = await DB.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(from s in DB.Status select new { s.StatusID, s.StatusName }
             , "StatusID", "StatusName");

            return PartialView(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Game game, HttpPostedFileBase file, HttpPostedFileBase file1)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(game).State = EntityState.Modified;
                await DB.SaveChangesAsync();
                TempData["Msg"] = "تمت عملية التعديل بنجاح";
                if (file.ContentLength > 0)
                {
                    var path = Server.MapPath("~/Images/Games/") + game.GameID + ".jpg";
                    file.SaveAs(path);
                }

                if (file1.ContentLength > 0)
                {
                    var path1 = Server.MapPath("~/Images/Games/") + game.GameID + ".swf";
                    file1.SaveAs(path1);
                }
                return RedirectToAction("Index");
            }
            return PartialView(game);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Game game = await DB.Games.FindAsync(id);
            DB.Games.Remove(game);
            await DB.SaveChangesAsync();
            System.IO.File.Delete(Server.MapPath("~/Images/Games/") + game.GameID + ".jpg");
            System.IO.File.Delete(Server.MapPath("~/Images/Games/") + game.GameID + ".swf");
            TempData["Msg"] = "تمت عملية الحذف بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id = 0)
        {
            Game game = await DB.Games.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return PartialView(game);
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
