/// <reference path="../anonymousApp.js" />

MyApp.controller('faqController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.commonQuestions = 'COMMON_QUESTIONS';
    $http.get('/FAQ/GetAllFAQ').success(function (data) {
        $scope.faqs = data;
    }).error(function () {
        alert("error");
    });
}]);