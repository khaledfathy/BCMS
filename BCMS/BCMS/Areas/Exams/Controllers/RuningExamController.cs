using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;

namespace BCMS.Areas.Exams.Controllers
{
    public class RuningExamController : Controller
    {
        BorsaCapitalDB DB = new BorsaCapitalDB();
        public ActionResult Index(int category)

        {
           // category = 5;
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
            #region sss
            //var Result = ((from x in DB.questions
            //               where x.subcategory_id == SubCat
            //                 select new{ id = x.id}).Take(1)
            //         .Union((from x in DB.questions
            //                 where x.subcategory_id == SubCat
            //                 orderby x.id descending
            //                 select new{ id = x.id}).Take(1)
            //         )).ToList();

            //int[] Nums = new int[100];

            //int[] FirstAndLast = new int [2];

            //int index = 0;
            //foreach (var item in Result)
            //{
            //    FirstAndLast[index] = item.id;
            //    index++;
            //}
            #endregion
            #region mmmmm
            /*
            for (int i = 0; i < Nums.Length; i++)
            {
                bool Flag = false;
                int n = new Random().Next(FirstAndLast[0], FirstAndLast[1] + 1);
                while (!Flag)
                {
                    for (int x = i; x >= 0; x--)
                    {
                        if (Nums[x] == n)
                        {
                            Flag = false;
                            Nums[i] = 0;
                            n = new Random().Next(FirstAndLast[0], FirstAndLast[1] + 1);
                            break;
                        }
                        else
                        {
                            Nums[i] = n;
                            Flag = true;
                        }

                    }//End Small For
                }//End While
            }//End Big For
            */
            #endregion

            //Nums[0] = new Random().Next(201, 301);

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