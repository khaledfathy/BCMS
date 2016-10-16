using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;

namespace BCMS.Areas.Exams.Controllers
{
    [Authorize]
    public class RuningExamController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
        public ActionResult Index(int category)
        {
            Session["tttt"] = category;
            return View();
        }

        [HttpPost]
        public JsonResult SaveResult(string Correct, string Wrong, string Blank, string user, string cat)
        {
            ExamResult r = new ExamResult();
            r.username = user;
            r.subcategory_id = Convert.ToInt32(cat);
            r.correct_a = Convert.ToInt32(Correct);
            r.wrong_a = Convert.ToInt32(Wrong);
            r.not_answered = Convert.ToInt32(Blank);
            DB.ExamResults.Add(r);
            DB.SaveChanges();
            return Json("Done", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetQuestion(string QuizNo)
        {
            int No = Convert.ToInt32(QuizNo);
            string Quiz = DB.ExamQuestions.FirstOrDefault(x => x.id == No).quiz_text;
            return Json(Quiz, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAnswers(string QuizNo)
        {
            int No = Convert.ToInt32(QuizNo);
            var Ans = DB.ExamAnswer_question.Where(x => x.ques_id == No).Select(a => new { a.answer, a.is_right }).ToList().OrderBy(s => Guid.NewGuid());
            return Json(Ans, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRandomNumbers()
        {
            //int SubCat = Convert.ToInt32(Session["max_category"]);
            int SubCat = Convert.ToInt32(Session["tttt"]);
           
            var Random_id = DB.ExamQuestions.Where(x => x.subcategory_id == SubCat).Select(a => a.id).OrderBy(s => Guid.NewGuid()).ToList();
         
            return Json(Random_id, JsonRequestBehavior.AllowGet);
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