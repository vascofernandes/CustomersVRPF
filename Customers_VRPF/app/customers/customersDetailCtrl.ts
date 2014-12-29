/// <reference path='../_all.ts' />

(function () {
    "use strict";

    function CustomersDetailCtrl(customer) {
        var vm = this;

        vm.customer = customer;
    }

    angular.module("customers").controller("CustomersDetailCtrl", ["customer", CustomersDetailCtrl]);

})();
 