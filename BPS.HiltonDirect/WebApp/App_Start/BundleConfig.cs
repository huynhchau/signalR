using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace BPS.HiltonDirect.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            var bundle = new ScriptBundle("~/bundles/scripts")
                //.IncludeDirectory("~/Scripts/", "*.js", true)
                .Include("~/Scripts/libraries/jquery-1.11.1.js")
                .Include("~/Scripts/libraries/jquery-ui.js")
                .Include("~/Scripts/libraries/jquery.signalR-2.2.2.js")
                .Include("~/Scripts/libraries/angular.js")
                .Include("~/Scripts/libraries/bootstrap.js")
                .Include("~/Scripts/libraries/angular-ui-router.js")
                .Include("~/Scripts/libraries/angular-ui/ui-bootstrap-tpls.js")
                .Include("~/Scripts/libraries/angular-sanitize.js")
                .Include("~/Scripts/libraries/angular-file-upload.js")
                .Include("~/Scripts/libraries/angular-block-ui.js")
                .Include("~/Scripts/libraries/angular-ui/ui-utils.js")
                .Include("~/Scripts/libraries/cache.js")
                .Include("~/Scripts/application/core/global.js")
                .Include("~/Scripts/libraries/showErrors.js")
                .Include("~/Scripts/libraries/tinymce/tinymce.js")
                .Include("~/Scripts/libraries/select.js")
                .Include("~/Scripts/libraries/jquery.cookie.js")
                .Include("~/Scripts/libraries/angular-dialogs.js")

                .IncludeDirectory("~/Scripts/application/core", "*.js", true)
                .IncludeDirectory("~/Scripts/application/providers", "*.js", true)
                .IncludeDirectory("~/Scripts/application/services", "*.js", true)
                .IncludeDirectory("~/Scripts/application/views", "*.js", true);

            bundle.Transforms.Clear();
            bundle.Orderer = new NonOrderingBundleOrderer();

            var styleBundle = new StyleBundle("~/bundles/Content")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-custom.css")
                .Include("~/Content/font-awesome.css")
                .Include("~/Content/Site.css")
                .Include("~/Content/select.css");

            bundle.Transforms.Clear();
            bundle.Orderer = new NonOrderingBundleOrderer();

            bundles.Add(styleBundle);
            bundles.Add(bundle);
        }

        class NonOrderingBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }
        }

        class Test : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
