using System.Web.Mvc;

namespace BCMS.Areas.Games
{
    public class GamesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "xxxGames";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "xxxGames_default",
                "xxxGames/{controller}/{action}/{id}",
                new { action = "GameIndex", id = UrlParameter.Optional }
            );
        }
    }
}