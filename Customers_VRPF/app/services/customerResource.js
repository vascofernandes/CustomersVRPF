/// <reference path='../_all.ts' />
var App;
(function (App) {
    "use strict";
    angular.module("services").factory("customersResource", ["$resource", customersResource]);
    function customersResource($resource) {
        return $resource("/api/customers/:customerId", null, {
            "update": { method: "PUT" }
        });
    }
})(App || (App = {}));
//# sourceMappingURL=customerresource.js.map