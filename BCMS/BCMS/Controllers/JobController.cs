using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
namespace BCMS.Controllers
{
    public class JobController : Controller
    {
       
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
   
        public JsonResult GetAllJobs()
        {
           
            return Json(DB.Jobs.Select(x => new
            {
                JobID = x.JobID,
                JobTitle = x.JobTitle,
                specification = x.Job_Specification.Select(s=>s.specification),
                education = x.Job_Education.Select(e => e.Education),
                prefer = x.Job_Prefer.Select(p => p.Prefer),
                skill = x.Job_Skill.Select(sk => sk.Skill)
            }), JsonRequestBehavior.AllowGet);
               
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