﻿/// <reference path='../_all.ts' />

module App {
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
}

/*
(function () {
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

})();
*/

/*
(function () {
    "use strict";

    //create angularjs controller
    var app = angular.module("customers", []);//set and get the angular module
    app.controller("customerController", ["$scope", "$http", customerController]);

    //angularjs controller method
    function customerController($scope, $http) {

        //declare variable for mainain ajax load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;

        //get all customer information
        $http.get("/api/customers/").success(function (data) {
            $scope.customers = data;
            $scope.loading = false;
        })
        .error(function (data, status, headers, config) {
            console.log(data);
            console.log(status);
            console.log(headers);
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            this.customer.editMode = !this.customer.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //Inser Customer
        $scope.add = function () {
            $scope.loading = true;
            $http.post("/api/customers/", this.newcustomer).success(function (data) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                $scope.customers.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Adding Customer! " + data;
                $scope.loading = false;
            });
        };

        //Edit Customer
        $scope.save = function () {
            alert("Edit");
            $scope.loading = true;
            var frien = this.customer;
            alert(frien);
            $http.put("/api/customers/" + frien.Id, frien).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving customer! " + data;
                $scope.loading = false;
            });
        };

        //Delete Customer
        $scope.deletecustomer = function () {
            $scope.loading = true;
            var Id = this.customer.Id;
            $http.delete("/api/customers/" + Id).success(function (data) {
                alert("Deleted Successfully!!");
                $.each($scope.customers, function (i) {
                    if ($scope.customers[i].Id === Id) {
                        $scope.customers.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Customer! " + data;
                $scope.loading = false;
            });
        };

    }

})();
*/ 