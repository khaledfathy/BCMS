/// <reference path="../anonymousApp.js" />

MyApp.controller('JobsController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    // Set page title
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Jobs | Borsa Capital');
    } else {
        Page.setTitle('وظائف شاغرة | بورصة كابيتال');
    }
    // Translation
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.availableJobs = 'AVAILABLE_JOBS';
    // Get Jobs request
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

