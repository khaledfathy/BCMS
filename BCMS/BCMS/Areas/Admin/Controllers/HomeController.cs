using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BCMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            Session["PageTitle"] = "الرئيسية";
            return View();
        }
        
    }
}
