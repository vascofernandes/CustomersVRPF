
(function () {
    "use strict";

    function customersResource($resource) {
        return $resource("/api/customers/:customerId", null, {
            "update": { method: "PUT" }
        });
    }
    angular.module("services").factory("customersResource", ["$resource", customersResource]);

})();


