using System.Web;
using System.Web.Optimization;

namespace Zen.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //全局CSS支持
            bundles.Add(new StyleBundle("~/Style/Global").Include(
                "~/Styles/FortAwesome/css/font-awesome.css",
                "~/Styles/pannonia.css"));

            //全局JS支持
            //*jq
            //*bootstrap插件
            bundles.Add(new ScriptBundle("~/Script/Global").Include(
                "~/Scripts/jquerymin.js",
                "~/Scripts/bootstrap.js"));
        }
    }
}