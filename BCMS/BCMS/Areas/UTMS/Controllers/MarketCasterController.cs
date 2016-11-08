using BCMS.Areas.UTMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.UTMS.Controllers
{
    public class MarketCasterController : Controller
    {
        public ActionResult GetMessages()
        {
            try
            {
                MessagesRepository _messageRepository = new MessagesRepository();
                return PartialView("~/Areas/UTMS/Views/MarketCaster/_MarketCaster.cshtml", _messageRepository.GetAllMessages());
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}