
using System.Web.Optimization;

namespace Blog
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/indexJs")
                .Include("~/assets/vendor/bootstrap/js/bootstrap.bundle.min.js",
                    "~/assets/vendor/swiper/swiper-bundle.min.js",
                    "~/assets/vendor/glightbox/js/glightbox.min.js",
                    "~/assets/vendor/aos/aos.js",
                    "~/assets/vendor/php-email-form/validate.js",
                    "~/assets/js/main.js"
                    )
                
            
            );
            bundles.Add(new StyleBundle("~/indexCss")
                .Include("~/assets/vendor/bootstrap/css/bootstrap.min.css",
                    "~/assets/vendor/bootstrap-icons/bootstrap-icons.css",
                    "~/assets/vendor/swiper/swiper-bundle.min.css",
                    "~/assets/vendor/glightbox/css/glightbox.min.css",
                    "~/assets/vendor/aos/aos.css",
                    "~/assets/css/variables.css",
                    "~/assets/css/main.css")
            
                
            );
            //bundles.Add(new StyleBundle("~/indexFavIcon")
            //    .Include("~/assets/img/favicon.png",
            //        "~/assets/img/apple-touch-icon.png"));
        }
    }
}
