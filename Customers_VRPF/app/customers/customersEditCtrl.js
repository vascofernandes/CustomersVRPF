(function () {
    "use strict";

    angular.module("customers").controller("CustomersEditCtrl", ["$window", "customer", CustomersEditCtrl]);

    function CustomersEditCtrl($window, customer) {
        var vm = this;

        vm.customer = customer;

        vm.goBack = function () {
            $window.history.back();
        };
    }

})();
