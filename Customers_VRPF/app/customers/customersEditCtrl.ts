/// <reference path='../_all.ts' />

(function () {
    "use strict";

    angular.module("customers").controller("CustomersEditCtrl", ["$window", "customersResource", "customer", CustomersEditCtrl]);

    function CustomersEditCtrl($window, customersResource, customer) {
        var vm = this;

        vm.loading = false;
        vm.customer = customer;

        vm.goBack = function () {
            $window.history.back();
        };

        vm.save = function (customer) {
            vm.loading = true;

            customersResource.update({ customerId: customer.Id }, customer, function (data) {
                alert("Saved Successfully!!");
                vm.loading = false;
                vm.goBack();
            });
        };


    }

})();
 