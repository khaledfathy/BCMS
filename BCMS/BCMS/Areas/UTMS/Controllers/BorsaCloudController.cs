using BCMS.Areas.UTMS.Models;
using BCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    [Authorize]
    public class BorsaCloudController : Controller
    {
        BorsaCapitalDataModel DB = new BorsaCapitalDataModel();
          
        public ActionResult GetMessages()
        {
            try
            {
                MessagesRepository _messageRepository = new MessagesRepository();
                return PartialView("~/Areas/UTMS/Views/BorsaCloud/_BorsaCloud.cshtml", _messageRepository.GetSectorsAndCategories());

            }

            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
      
    }
}
