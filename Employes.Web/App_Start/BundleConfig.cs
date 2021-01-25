using System.Web;
using System.Web.Optimization;

namespace Employes.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/jquery-1.12.1.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/employeList").Include(
                "~/Scripts/employeList.js"));
            bundles.Add(new ScriptBundle("~/bundles/addList").Include(
                "~/Scripts/addList.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Content/font-awesome-4.7.0/css/font-awesome.css",
                "~/Content/font-awesome-4.7.0/css/font-awesome.min.css"));
        }
    }
}
