using System.Web;
using System.Web.Optimization;

namespace AThousandCounts
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/metro").Include(
                        "~/Scripts/metro/metro-min.js",
                        "~/Scripts/metro/accordion.js",
                        "~/Scripts/metro/buttonset.js",
                        "~/Scripts/metro/calendar.js",
                        "~/Scripts/metro/carousel.js",
                        "~/Scripts/metro/contextmenu.js",
                        "~/Scripts/metro/dialog.js",
                        "~/Scripts/metro/dropdown.js",
                        "~/Scripts/metro/input-control.js",
                        "~/Scripts/metro/pagecontrol.js",
                        "~/Scripts/metro/pagelist.js",
                        "~/Scripts/metro/rating.js",
                        "~/Scripts/metro/slider.js",
                        //"~/Scripts/metro/start-menu.js", //missing startmenu
                        "~/Scripts/metro/tile-drag.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/MetroCss").Include(
                      "~/Content/css/iconFont.min.css",
                      "~/Content/css/metro-bootstrap-responsive.min.css",
                      "~/Content/css/metro-bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
