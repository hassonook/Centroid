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
                        "~/Content/plugins/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/plugins/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusive").Include(
                        "~/Content/plugins/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/isotope").Include(
                        "~/Content/plugins/isotope/isotope.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/backstretch").Include(
                        "~/Content/plugins/jquery.backstretch.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/appear").Include(
                        "~/Content/plugins/jquery.appear.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqBootstrapValidation").Include(
                        "~/Content/contact/jqBootstrapValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/contact_me").Include(
                        "~/Content/contact/contact_me.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Content/js/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/slider").Include(
                        "~/Content/js/jquery.devrama.slider.min-0.9.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                        "~/Content/plugins/tinymce/tinymce.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/plugins/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/plugins/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                       "~/Content/plugins/DataTables/datatables.min.js"));

            /////Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/css/bootstrap.css",
                      "~/Content/fonts/font-awesome/css/font-awesome.css",
                      "~/Content/css/animations.css",
                      "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/plugins/DataTables/datatables.min.css"));

        }
    }
}
