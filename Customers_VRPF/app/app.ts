/// <reference path='_all.ts' />

module App {
    "use strict";

    angular.module("customers", ["ui.router", "services"]);

    angular.module("customers").config(["$stateProvider", "$urlRouterProvider", customersConfig]);

    function customersConfig($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/customers");

        $stateProvider
        .state("customersList", {
            url: "/customers",
            templateUrl: "app/customers/customersListView.html",
            controller: "CustomersListCtrl as vm"
        })
        .state("customersDetail", {
            url: "/customers/:customerId/view",
            templateUrl: "app/customers/customersDetailView.html",
            controller: "CustomersDetailCtrl as vm",
            resolve: {
                customersResource: "customersResource",

                customer: function (customersResource, $stateParams) {
                    var customerId = $stateParams.customerId;
                    // Forcing resolution before the controller executes with $promise
                    return customersResource.get({ customerId: customerId }).$promise;
                }
            }
        })
        .state("customersEdit", {
            url: "/customers/:customerId/edit",
            templateUrl: "app/customers/customersEditView.html",
            controller: "CustomersEditCtrl as vm",
            resolve: {
                customersResource: "customersResource",

                customer: function (customersResource, $stateParams) {
                    var customerId = $stateParams.customerId;
                    // Forcing resolution before the controller executes with $promise
                    return customersResource.get({ customerId: customerId }).$promise;
                }
            }
        });
    }
}
