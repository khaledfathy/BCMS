﻿
/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/angular.js" />
/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/angular-translate.js" />
/// <reference path="langApp.js" />


// Layout Header Controller
langApp.controller("headerController",["$scope","$timeout", function ($scope, $timeout) {
    $scope.login = 'login';
    $scope.logout = 'logout';
    $scope.register = 'register';
    $scope.welcome = 'welcome';
    $scope.pixel = 'pixel';
    $scope.feedback = 'feedback';
    $scope.onlineSupport = 'onlineSupport';
    $scope.search = 'search';
    $scope.home = 'home';
    $scope.about = 'about';
    $scope.bcWord = 'bcWord';
    $scope.aboutKSA = 'aboutKSA';
    $scope.commonQuestions = 'COMMON_QUESTIONS';
    $scope.jobs = 'jobs';
    $scope.pyramidServices = 'pyramidServices';
    $scope.download = 'download';
    $scope.demo = 'demo';
    $scope.partners = 'partners';
    $scope.contactus = 'contactus';
    // Call datetime function
    dateTime('time');
}]);

// Layout Footer Controller
langApp.controller('footerController',["$scope", function ($scope) {
    $scope.bc = 'bc';
    $scope.bcWord = 'bcWord';
    $scope.aboutKSA = 'aboutKSA';
    $scope.about = 'about';
    $scope.partners = 'partners';
    $scope.sayingsOfWise = 'sayingsOfWise';
    $scope.feedback = 'feedback';
    $scope.jobs = 'jobs';
    $scope.contactus = 'contactus';
    $scope.ourServices = 'ourServices';
    $scope.pyramidServices = 'pyramidServices';
    $scope.download = 'download';
    $scope.investmentAdvices = 'investmentAdvices';
    $scope.pixel = 'pixel';
    $scope.register = 'register';
    $scope.login = 'login';
    $scope.education = 'education';
    $scope.library = 'library';
    $scope.exams = 'exams';
    $scope.terminology = 'terminology';
    $scope.commonQuestions = 'COMMON_QUESTIONS';
    $scope.educationalVideos = 'educationalVideos';
    $scope.educationalGames = 'educationalGames';
    $scope.entertainment = 'entertainment';
    $scope.caricature = 'caricature';
    $scope.entertainmentGames = 'entertainmentGames';
    $scope.music = 'music';
    $scope.videos = 'relaxingVideos';
    $scope.siteMap = 'siteMap';
    $scope.copyRights = 'copyRights';
}]);

// Current Date and Time function
function dateTime(id) {
    date = new Date;
    year = date.getFullYear();
    month = date.getMonth();
    var lang = getCookie('language');
    if (lang == 'en')
        months = new Array('January', 'February', 'March', 'April', 'May', 'June', 'Jully', 'August', 'September', 'October', 'November', 'December');
    else
        months = new Array('يناير', 'فبراير', 'مارس', 'ابريل', 'مايو', 'يونية', 'يوليو', 'اغسطس', 'سبتمبر', 'اكتوبر', 'نوفمبر', 'ديسمبر');

    d = date.getDate();
    day = date.getDay();
    h = date.getHours();
    if (h < 10) {
        h = "0" + h;
    }
    m = date.getMinutes();
    if (m < 10) {
        m = "0" + m;
    }
    s = date.getSeconds();
    if (s < 10) {
        s = "0" + s;
    }
    result = '' + d + ' ' + months[month] + ' ' + year + ',  ' + h + ':' + m + ':' + s;
    document.getElementById(id).innerHTML = result;
    setTimeout('dateTime("' + id + '");', '1000');
    return true;
}
