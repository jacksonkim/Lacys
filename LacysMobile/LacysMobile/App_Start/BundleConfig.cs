using System.Web;
using System.Web.Optimization;

namespace LacysMobile.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // script bundles
            bundles.Add(new ScriptBundle("~/Bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/Bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/Bundles/Bootstrap").Include("~/Scripts/Bootstrap/affix.js",
                                                                        "~/Scripts/Bootstrap/alert.js",
                                                                        "~/Scripts/Bootstrap/button.js",
                                                                        "~/Scripts/Bootstrap/carousel.js",
                                                                        "~/Scripts/Bootstrap/collapse.js",
                                                                        "~/Scripts/Bootstrap/dropdown.js",
                                                                        "~/Scripts/Bootstrap/modal.js",
                                                                        "~/Scripts/Bootstrap/tooltip.js",
                                                                        "~/Scripts/Bootstrap/popover.js",
                                                                        "~/Scripts/Bootstrap/scrollspy.js",
                                                                        "~/Scripts/Bootstrap/tab.js",
                                                                        "~/Scripts/Bootstrap/transition.js"));

            bundles.Add(new ScriptBundle("~/Bundles/jquerymobile").Include("~/Scripts/-{version}.jquery.mobile.js"));
            
            // styles bundles
            bundles.Add(new StyleBundle("~/Content/Bootstrap").Include("~/Content/Bootstrap/less/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/Bootstrap/BootstrapTheme").Include("~/Content/Bootstrap/BootstrapTheme/bootstrapTheme.css"));

            bundles.Add(new StyleBundle("~/Content/Layout").Include("~/Content/Layout/layout.css"));

            bundles.Add(new StyleBundle("~/Content/CSS").Include());
        }
    }
}