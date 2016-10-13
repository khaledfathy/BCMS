using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;

namespace BCMS.Areas.UTMS.Controllers
{
    public class KnowledgeController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();

        [HttpGet]
        public JsonResult GetAllKnowledge()
        {
            return Json(DB.Knowledges.Select(x => new {
                KnowledgeID = x.KnowledgeID,
                KnowledgeTitle = x.KnowledgeTitle,
                informatoins = x.Information.Select(e => e.InformationTitle).ToList()

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