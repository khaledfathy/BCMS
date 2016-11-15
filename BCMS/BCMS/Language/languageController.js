/// <reference path="langApp.js" />
/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/jquery-1.10.2.js" />


// Language controller
MyApp.controller("languageController", function ($scope, $translate, $cookies) {
    var lang = $cookies.get('language');
    if (lang == 'en') {
        $scope.arabic = false;
    }
    else
        $scope.arabic = true;

    // Change Language 
    $scope.switchLanguage = function (langKey) {
        $cookies.put('language', langKey, { path: "/" });
        location.reload();
    }
});