using System.Web;
using System.Web.Optimization;

namespace Centroid
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusive").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/isotope").Include(
                        "~/Scripts/isotope/isotope.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/backstretch").Include(
                        "~/Scripts/jquery.backstretch.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appear").Include(
                        "~/Scripts/jquery.appear.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqBootstrapValidation").Include(
                        "~/Scripts/contact/jqBootstrapValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/contact_me").Include(
                        "~/Scripts/contact/contact_me.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Content/js/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                        "~/Content/js/jquery.devrama.slider.min-0.9.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                        "~/Scripts/tinymce/tinymce.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                       "~/Scripts/DataTables/datatables.min.js"));

            /////Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.css",
                      "~/Content/fonts/font-awesome/css/font-awesome.css",
                      "~/Content/animations.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/plugins/DataTables/datatables.min.css"));

        }
    }
}
