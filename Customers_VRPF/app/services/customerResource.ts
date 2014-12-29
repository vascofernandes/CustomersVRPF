/// <reference path='../_all.ts' />
module App {
    "use strict";

    angular.module("services").factory("customersResource", ["$resource", customersResource]);

    function customersResource($resource) {
        return $resource("/api/customers/:customerId", null, {
            "update": { method: "PUT" }
        });
    }

}

/*
(function () {
    "use strict";
    
    angular.module("services").factory("customersResource", ["$resource", customersResource]);

    function customersResource($resource) {
        return $resource("/api/customers/:customerId", null, {
            "update": { method: "PUT" }
        });
    }
    
})();
*/
