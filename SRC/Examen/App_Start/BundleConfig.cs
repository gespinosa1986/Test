using System.Web;
using System.Web.Optimization;

namespace Examen
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
                      "~/Content/bootstrap-theme.min.css"));

            /********************************** Scripts System **********************************/

            bundles.Add(new ScriptBundle("~/Scripts/Account").Include("~/Scripts/SystemScripts/AccountScript.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Home").Include("~/Scripts/SystemScripts/HomeScript.js"));

            /*********************************** Style System ***********************************/

            bundles.Add(new StyleBundle("~/Content/Account").Include("~/Content/SystemStyles/AccountStyle.css"));
            bundles.Add(new StyleBundle("~/Content/Home").Include("~/Content/SystemStyles/HomeStyle.css"));
        }
    }
}
