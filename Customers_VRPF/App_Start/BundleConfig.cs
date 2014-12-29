﻿using System.Web;
using System.Web.Optimization;

namespace Customers_VRPF
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-resource.min.js",
                        "~/Scripts/angular-ui-router.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/customerjs").Include(
                        "~/app/app.js",
                        "~/app/services/services.js",
                        "~/app/services/customerResource.js",
                        "~/app/customers/customersListCtrl.js",
                        "~/app/customers/customersEditCtrl.js",
                        "~/app/customers/customersDetailCtrl.js"));
        }
    }
}
