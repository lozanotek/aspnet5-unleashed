(function () {
    "use strict";

    var speakers = angular.module("speakers");

    speakers.factory("speakerService", ["$http",
        function ($http) {
            var service = {};

            service.getSpeakers = function () {
                return $http.get("api/speakers");
            };

            return service;
        }
    ]);
})();
