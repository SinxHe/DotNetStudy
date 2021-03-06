﻿using System.Web;
using System.Web.Optimization;

namespace N32WebUi
{
    public class BundleConfig
    {

        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 自动加的
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            #endregion

            #region MVC异步和注解验证
            bundles.Add(new ScriptBundle("~/MvcMinJQuery")
                    .Include("~/Scripts/jquery-1.8.2.min.js")
                    .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                    .Include("~/Scripts/jquery.validate.min.js")
                    .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                    .Include("~/Scripts/Heab-AjaxModel.js"));
            #endregion

            #region EasyUi
            #region JQuery - @Scripts.Render("~/EasyUiJQuery")
            bundles.Add(new ScriptBundle("~/EasyUiJQuery")
                        .Include("~/EasyUi/jquery.min.js")
                        .Include("~/EasyUi/jquery.easyui.min.js")
                        .Include("~/EasyUi/easyui-lang-zh_CN.js")
                        .Include("~/Scripts/Heab-AjaxModel.js")); 
            #endregion
            #region CSS - @Styles.Render("~/EasyUi/themes/default/css")
            // 放到Bundle中会拿不到图片(浏览器请求虚拟路径问题, 除非自定义名字也是一个合适的路径)
            bundles.Add(new StyleBundle("~/EasyUi/themes/default/css")
                .Include("~/EasyUi/themes/icon.css")
                .Include("~/EasyUi/themes/default/easyui.css"));  
            #endregion
            #endregion

            BundleTable.EnableOptimizations = true; // 开启合并
        }

    }
}