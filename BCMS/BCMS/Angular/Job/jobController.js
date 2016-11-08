/// <reference path="../anonymousApp.js" />

MyApp.controller('JobsController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.availableJobs = 'AVAILABLE_JOBS';

    $http.get('/Job/GetAllJobs').success(function (data) {
        if (data == "Error") {

            window.location.href = "/Home/Error";
        }
        else {
            $scope.jobs = data;

        }
    }).error(function (error) {
        window.location.href = "/Home/Error";
    });
}]);

