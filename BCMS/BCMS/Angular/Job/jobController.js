/// <reference path="../anonymousApp.js" />

MyApp.controller('JobsController', ["$scope", "$http", function ($scope, $http) {
    
    DoLoading();
    $scope.loading = true;
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.availableJobs = 'AVAILABLE_JOBS';
    
    $http.get('/Job/GetAllJobs').success(function (data) {
        $scope.jobs = data;
        $scope.loading = false;
    }).error(function (error) {
        alert(error);
    });
}]);

