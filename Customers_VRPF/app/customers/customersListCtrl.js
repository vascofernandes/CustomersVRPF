/// <reference path='../_all.ts' />
var App;
(function (App) {
    "use strict";
    angular.module("customers").controller("CustomersListCtrl", ["$scope", "$http", "customersResource", CustomersListCtrl]);
    function CustomersListCtrl($scope, $http, customersResource) {
        var vm = this;
        vm.loading = true;
        vm.addMode = false;
        //Get all customer information
        customersResource.query(function (data) {
            vm.customers = data;
            vm.loading = false;
        });
        vm.toggleAdd = function () {
            vm.addMode = !vm.addMode;
        };
        //Insert New Customer
        vm.add = function (newcustomer) {
            vm.loading = true;
            customersResource.save(newcustomer, function (data) {
                alert("Added Successfully!!");
                vm.addMode = false;
                vm.customers.push(data);
                vm.loading = false;
            });
        };
        //Delete Customer
        vm.deletecustomer = function (customer) {
            if (!confirm("Are you sure ?")) {
                return;
            }
            vm.loading = true;
            var id = customer.Id;
            customersResource.delete({ customerId: id }, function (data) {
                alert("Deleted Successfully!!");
                $.each(vm.customers, function (idx) {
                    if (vm.customers[idx].Id === id) {
                        vm.customers.splice(idx, 1);
                        return false;
                    }
                    return null;
                });
                vm.loading = false;
            });
        };
    }
})(App || (App = {}));
//# sourceMappingURL=customerslistctrl.js.map