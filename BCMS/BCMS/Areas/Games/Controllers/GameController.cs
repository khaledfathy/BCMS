using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMS.Areas.Games.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: NewGames/Home

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MemeoryGame()
        {

            return View();
        }
        public ActionResult SpaceGame()
        {

            return View();
        }
    }
}