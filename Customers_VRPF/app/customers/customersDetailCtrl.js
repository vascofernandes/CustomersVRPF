(function () {
    "use strict";

    angular.module("customers").controller("CustomersDetailCtrl", ["customer", CustomersDetailCtrl]);

    function CustomersDetailCtrl(customer) {
        var vm = this;

        vm.customer = customer;
    }

})();
