/// <reference path="../anonymousApp.js" />

MyApp.controller('faqController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    // Set page title
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('FAQ | Borsa Capital');
    } else {
        Page.setTitle('أسألة متكررة | بورصة كابيتال');
    }
    // Translation
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.commonQuestions = 'COMMON_QUESTIONS';
    // Get FAQs request 
    $http.get('/FAQ/GetAllFAQ').success(function (data) {
        if (data == "Error") {
            window.location.href = "/Home/Error";
        }
        else
            $scope.faqs = data;
    }).error(function () {
        window.location.href = "/Home/Error";
    });
}]);