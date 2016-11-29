using System.Web;
using System.Web.Optimization;

namespace BCMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bundles"></param>

        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Anonimous
            bundles.Add(new StyleBundle("~/bundles/BCMS/style/ar").Include(
                "~/Materials/Ar/css/foundation.css",
                //"~/Materials/Ar/css/MainStyle.css",
                "~/Materials/Ar/css/Inputs.css",
                "~/Materials/Ar/Sliding/css/Sliding.css",
                "~/Materials/Ar/MainMenu/css/component.css",
                "~/Materials/Ar/MainMenu/css/default.css",
                "~/Materials/Ar/MainMenu/css/css3.css",
                "~/Materials/Ar/Slider/responsiveslides.css",
                "~/Materials/Ar/css/login.css",
                "~/Materials/Ar/css/alerts/normalize.css",
                "~/Materials/Ar/css/alerts/alertify.rtl.css",
                "~/Materials/Ar/css/alerts/themes/default.css",
                 "~/Content/loading-bar.css",
                "~/Materials/UTMS/css/borsagraphicspobup.css",
                "~/Materials/droidarabickufi.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/MainStyle/ar")
                   .Include("~/Materials/Ar/css/MainStyle.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/MainStyle/en")
                   .Include("~/Materials/En/css/MainStyle.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/BCMS/style/en").Include(
                "~/Materials/En/css/foundation.css",
                //"~/Materials/En/css/MainStyle.css",
                "~/Materials/En/css/Inputs.css",
                "~/Materials/En/Sliding/css/Sliding.css",
                "~/Materials/En/MainMenu/css/component.css",
                "~/Materials/En/MainMenu/css/default.css",
                "~/Materials/En/MainMenu/css/css3.css",
                "~/Materials/En/Slider/responsiveslides.css",
                "~/Materials/En/css/login.css",
                "~/Materials/En/css/alerts/normalize.css",
                "~/Materials/En/css/alerts/alertify.rtl.css",
                "~/Materials/En/css/alerts/themes/default.css",
                "~/Content/loading-bar.css",
                "~/Materials/UTMS/css/borsagraphicspobup.css",
                "~/Materials/droidarabickufi.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/BCMS/script").Include(
                "~/Scripts/jquery.js",
                "~/Scripts/alertify.js",
                "~/scripts/angular.js",
                "~/Scripts/angular-video-bg.js",
                "~/scripts/angular-route.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-translate.js",
                "~/Angular/app_Anonimous.js",
                "~/Language/langApp.js",
                "~/Language/languageController.js",
                "~/Language/layoutController.js",
                "~/Angular/Account/accountController.js",
                "~/Angular/Account/accountService.js",
                "~/Angular/ContactUs/contactusController.js",
                "~/Angular/FAQ/faqController.js",
                "~/Angular/FeedBack/feedbackController.js",
                "~/Angular/Job/jobController.js",
                "~/Scripts/responsiveslides.js",
                "~/Scripts/mm-foundation-tpls-0.6.0.js",
                "~/Scripts/jquery.signalR-2.2.0.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/loading-bar.js"
                ));
            #endregion

            #region UTMS
            ////////////////////////////-- UTMS CSS --//////////////////////////////////

            bundles.Add(new StyleBundle("~/App_Start/bundles/UTMS/style").Include(
                "~/Materials/UTMS/css/foundation.css",
                //"~/Materials/UTMS/css/MainStyle.css",
                "~/Materials/UTMS/MainMenu/css/component.css",
                "~/Materials/UTMS/MainMenu/css/css3.css",
                "~/Materials/UTMS/css/Graphics.css",
                "~/Content/loading-bar.css",
                "~/Materials/UTMS/css/highcharts.css",
                "~/Materials/droidarabickufi.css"
                ));

            bundles.Add(new StyleBundle("~/UTMS/MainStyle/ar")
                  .Include("~/Materials/UTMS/css/MainStyle.css", new CssRewriteUrlTransform()));

            ////////////////////////////-- UTMS JS --//////////////////////////////////

            bundles.Add(new ScriptBundle("~/App_Start/bundles/UTMS/script").Include(
                "~/Scripts/jquery.js",
                "~/Scripts/jquery.signalR-2.2.0.js",
                "~/Scripts/modernizr.js",
                "~/Scripts/foundation.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/loading-bar.js",
                "~/Scripts/angular-route.js",
                "~/Areas/UTMS/Angular/app_UTMS.js",
                "~/Areas/UTMS/Angular/UTMS_Controller.js",
                "~/Scripts/highcharts.js",
                "~/Areas/UTMS/Charts/angular-google-maps.js",
                 "~/Scripts/highcharts-more.js",
                 "~/Scripts/solid-gauge.src.js"
                ));

            #endregion

            bundles.Add(new ScriptBundle("~/bundles/BCMS/cbpHorizontalMenu").Include(
                "~/Materials/Ar/MainMenu/js/cbpHorizontalMenu.js",
                "~/Materials/Ar/MainMenu/js/modernizr.custom.js",
                "~/Materials/Ar/Sliding/js/jquery.cookie.js",
                "~/Materials/Ar/Sliding/js/common.js",
                "~/Materials/UTMS/js/foundation.min.js"
               ));

            #region BCGame
            bundles.Add(new StyleBundle("~/bundles/BCGame/GameStyle").Include(
            "~/Materials/Games/css/foundation.css",
            "~/Materials/Games/css/Inputs.css",
            "~/Materials/Games/css/Flipp.css",
            "~/Materials/Games/css/Css3.css",
            "~/Materials/Games/css/MainStyle.css",
            "~/Materials/MainMenu/css/component.css",
            "~/Materials/MainMenu/css/default.css",
            "~/Materials/MainMenu/css/css3.css",
            "~/Materials/droidarabickufi.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/BCGame/script").Include(
                "~/Materials/Games/js/jquery-1.9.1.js",
                "~/Scripts/modernizr.custom.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Areas/Games/Angular/RouteController.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/BCGame/cbpHorizontalMenu").Include(
                "~/Scripts/cbpHorizontalMenu.js",
                "~/Scripts/jquery.foundation.min.js"

               ));
            #endregion


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            BundleTable.EnableOptimizations = true;

        }

    }
}
