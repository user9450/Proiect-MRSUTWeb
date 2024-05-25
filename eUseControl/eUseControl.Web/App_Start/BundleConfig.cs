using System.Web.Optimization;

namespace eUseControl.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //ScriptBundle: ~/Content/js | ~/Content/js/vendor | ~/Scripts/
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include("~/Сontent/js/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Content/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/scrollUp/js").Include("~/Сontent/js/scrollUp.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/venobox/js").Include("~/Сontent/js/venobox.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/ajax-mail/js").Include("~/Content/js/ajax-mail.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-nice-select/js").Include("~/Сontent/js/jquery.nice-select.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui/js").Include("~/Сontent/js/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-barrating/js").Include("~/Сontent/js/jquery.barrating.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/waypoints/js").Include("~/Сontent/js/waypoints.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-counterup/js").Include("~/Сontent/js/jquery.counterup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-countdown/js").Include("~/Сontent/js/jquery.countdown.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-mixitup/js").Include("~/Сontent/js/jquery.mixitup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/imagesloaded-pkgd/js").Include("~/Сontent/js/imagesloaded.pkgd.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/isotope-pkgd/js").Include("~/Сontent/js/isotope.pkgd.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/magnific-popup/js").Include("~/Сontent/js/jquery.magnific-popup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/owl-carousel/js").Include("~/Сontent/js/owl.carousel.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/slick/js").Include("~/Сontent/js/slick.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/wow/js").Include("~/Сontent/js/wow.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-meanmenu/js").Include("~/Сontent/js/jquery.meanmenu.min.js"));

            //From Vendor
            bundles.Add(new ScriptBundle("~/bundles/popper/js").Include("~/Сontent/js/vendor/popper.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-1.12.4/js").Include("~/Сontent/js/vendor/jquery-1.12.4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr-2.8.3/js").Include("~/Сontent/js/vendor/modernizr-2.8.3.min.js"));

            //From Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery-validate/js").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-3.7.1/js").Include("~/Scripts/jquery-3.7.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-3.7.1-min/js").Include("~/Scripts/jquery-3.7.1.min.js"));
            
            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include("~/Scripts/jquery.validate.min.js"));

            //StyleBundle: ~/Content/css/...
            bundles.Add(new StyleBundle("~/bundles/styles/material-design-iconic-font/css").Include("~/Content/css/material-design-iconic-font.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/font-awesome/css").Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/font-awesome-stars/css").Include("~/Content/css/fontawesome-stars.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/meanmenu/css").Include("~/Content/css/meanmenu.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/owl-carousel/css").Include("~/Content/css/owl.carousel.min.cs", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/slick/css").Include("~/Content/css/slick.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/animate/css").Include("~/Content/css/animate.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/jquery-ui/css").Include("~/Content/css/jquery-ui.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/venobox/css").Include("~/Content/css/venobox.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/nice-select/css").Include("~/Content/css/nice-select.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/magnific-popup/css").Include("~/Content/css/magnific-popup.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/bootstrap/css").Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/helper/css").Include("~/Content/css/helper.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/style/css").Include("~/Content/style.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/styles/responsive/css").Include("~/Content/css/responsive.css", new CssRewriteUrlTransform()));
        }
    }
}
