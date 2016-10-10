using System.Web.Mvc;

namespace BCMS.Areas.UTMS
{
    public class UTMSAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UTMS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UTMS_default",
                "UTMS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
