using System.Web.Mvc;

namespace BCMS.Areas.Exams
{
    public class ExamsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Exams";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Exams_default",
                "Exams/{controller}/{action}/{id}",
                new { action = "Category", id = UrlParameter.Optional }
            );
        }
    }
}