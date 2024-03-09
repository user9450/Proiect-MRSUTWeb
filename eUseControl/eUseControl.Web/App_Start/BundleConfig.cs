using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            // Bootstrap style

            //Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-3.7.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery/min").Include("~/Scripts/jquery-3.7.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Content/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            /*bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/style.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/font-awesome.css", new CssRewriteUrlTransform()));*/


        }
    }
}