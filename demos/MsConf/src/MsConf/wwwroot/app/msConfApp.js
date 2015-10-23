(function () {
    "use strict";

    var msConf = angular.module("msConf", ["ngRoute", "speakers"]);

    msConf.config([
        "$routeProvider",
        function ($routeProvider) {
            $routeProvider.when("/", {
                templateUrl: "app/templates/speaker-list.html",
                controller: "SpeakerController"
            });
        }
    ]);

    angular.module("speakers", ["ngRoute"]);
})();
