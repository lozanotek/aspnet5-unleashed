(function () {
    "use strict";

    var speakers = angular.module("speakers");

    speakers.controller("SpeakerController", [
        "$scope", "speakerService",
        function ($scope, speakerService) {
            $scope.loadSpeakers = function () {

                speakerService.getSpeakers()
                    .then(function (result) {
                        console.log(result.data);
                        $scope.speakers = result.data;
                    });
            };

            $scope.loadSpeakers();
        }
    ]);
})();
