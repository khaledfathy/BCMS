﻿/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/angular.js" />

var MyApp = angular.module('MyApp', ['ngRoute', 'mm.foundation', 'pascalprecht.translate']);

MyApp.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '/Angular/Home/Index.html',
        //templateUrl:'/Home/Home',
        controller: 'HomeController'
    })
    .when('/Login', {
        templateUrl: '/Angular/Account/Login.html',
        controller: 'LoginController'
    })
    .when('/Register', {
        templateUrl: '/Angular/Account/Register.html',
        controller: 'RegisterController'
    })
    .when('/ContactUs', {
        templateUrl: '/Angular/ContactUs/ContactUs.html',
        controller: 'ContactUsController'
    })
    .when('/Feedback', {
        templateUrl: '/Angular/FeedBack/Feedback.html',
        controller: 'FeedbackController'
    })
    .when('/AboutUs', {
        //templateUrl: '/Home/AboutUs',
        templateUrl: '/Angular/Home/AboutUs.html',
        controller: 'AboutUsController'
    })
    .when('/BCWord', {
        //templateUrl: '/Home/BCWord',
        templateUrl: '/Angular/Home/BCWord.html',
        controller: 'BCWordController'
    })
    .when('/AboutSaudi', {
        //templateUrl: '/Home/AboutSaudi',
        templateUrl: '/Angular/Home/AboutSaudi.html',
        controller: 'AboutSaudiController'
    })
    .when('/Demo', {
        //templateUrl: '/Demo/Index',
        templateUrl: '/Angular/Demo/Index.html',
        controller: 'DemoController'
    })
    .when('/Partners', {
        templateUrl: '/Angular/Home/Partners.html',
        controller: 'PartnersController'
    })
    .when('/PyramidServices', {
        templateUrl: '/Angular/Home/PyramidServices.html',
        controller: 'PyramidServicesController'
    })
    .when('/FAQ', {
        templateUrl: '/Angular/FAQ/Index.html',
        controller: 'faqController'
    })
    .when('/Jobs', {
        templateUrl: '/Angular/Job/Index.html',
        controller: 'JobsController'
    })
    .when('/SayingsOfWise', {
        templateUrl: '/Angular/Home/SayingsOfWise.html',
        controller: 'SayingsOfWiseController'
    })
    .when('/Advice', {
        templateUrl: '/Angular/Home/Advice.html',
        controller: 'AdviceController'
    })
    .when('/Terminology', {
        templateUrl: '/Angular/Home/Terminology.html',
        controller: 'TerminologyController'
    })
    .when('/Relaxing', {
        templateUrl: '/Angular/Home/Relaxing.html',
        controller: 'RelaxingController'
    })
    .when('/Games', {
        templateUrl: '/Angular/Entertainment/Games.html',
        controller: 'GamesController'
    })
    .when('/Music', {
        templateUrl: '/Angular/Entertainment/Music.html',
        controller: 'MusicController'
    })
    .when('/Forgotpassword', {
        templateUrl: '/Angular/Account/ForgotPassword.html',
        controller: 'ForgotpasswordController'
    })
    .when('/Resetpassword', {
        templateUrl: '/Angular/Account/ResetPassword.html',
        controller: 'ResetpasswordController'
    })
    .otherwise({
        redirectTo: '/'
    });

    //.when('/AdminstrationMessage', {
    //    templateUrl: 'AdminstrationMessage.html',
    //    controller: 'AdminstrationMessageController'
    //})
    //.when('/MyPortfolio', {
    //    templateUrl: '/Demo/MyPortfolio',
    //    controller: 'MyPortfolioController'
    //})
    //alert("Routing");
    //$locationProvider.html5Mode(true);
    //$locationProvider.html5Mode(true).hashPrefix('!');
}])

//.run( function($rootScope, $location) {
//    // register listener to watch route changes
//    $rootScope.$on( "$routeChangeStart", function(event, next, current) {
//        if ( $rootScope.loggedUser == null ) {
//            // no logged user, we should be going to #login
//            if (next.templateUrl == "/Account/Login") {
//                $location.path("/Login");
//                // already going to #login, no redirect needed
//            } if (next.templateUrl == "/Home/Index") {
//                $location.path("/");
//            }
//            else {
//                // not going to #login, we should redirect now
//                //doesn't refresh the page 
//                $location.path( "/" );
//            }
//        }         
//    });
//})

function DoLoading() {
    var opts = {
        lines: 13, // The number of lines to draw
        length: 16, // The length of each line
        width: 10, // The line thickness
        radius: 33, // The radius of the inner circle
        corners: 1, // Corner roundness (0..1)
        rotate: 49, // The rotation offset
        direction: 1, // 1: clockwise, -1: counterclockwise
        color: '#000', // #rgb or #rrggbb or array of colors
        speed: 2.2, // Rounds per second
        trail: 58, // Afterglow percentage
        shadow: false, // Whether to render a shadow
        hwaccel: false, // Whether to use hardware acceleration
        className: 'spinner', // The CSS class to assign to the spinner
        zIndex: 2e9, // The z-index (defaults to 2000000000)
        top: '50%', // Top position relative to parent
        left: '50%' // Left position relative to parent
    };
    var target = document.getElementById('loading');
    if (target != null && target != undefined && target != "") {
        var spinner = new Spinner(opts).spin(target);
        target.appendChild(spinner.el);
    }


    var TargetWithBackground = document.getElementById('loadingArea');
    if (TargetWithBackground != null && TargetWithBackground != undefined && TargetWithBackground != "") {
        var spinner1 = new Spinner(opts).spin(TargetWithBackground);
        TargetWithBackground.appendChild(spinner1.el);
    }

}

/**************************************************** Controllers ***********************************************************/

MyApp.controller('ChartController', function ($scope) {

});

MyApp.controller('BorsaCloudCtrl', function ($scope) {
    window.location.href = '/UTMS/Home/index';
});

MyApp.controller('HomeController', ["$scope", "$location", function ($scope) {
    $scope.bc = 'bc';
    $scope.ourServices = 'ourServices';
    $scope.education = 'education';
    $scope.entertainment = 'entertainment';

}]);

MyApp.controller('AboutUsController', ["$scope", function ($scope) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('BCWordController', ["$scope", function ($scope) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('AboutSaudiController', ["$scope", function ($scope) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('DemoController', ["$scope", function ($scope) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('PartnersController', ["$scope", function ($scope) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('PyramidServicesController', ["$scope", function ($scope) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('SayingsOfWiseController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('AdviceController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('TerminologyController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('GamesController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('RelaxingController', ["$scope", "$http", function ($scope, $http) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('AdminstrationMessageController', ["$scope", function ($scope) {

}]);

MyApp.controller('MyPortfolioController', ["$scope", function ($scope) {

}]);

MyApp.controller('MusicController', ["$scope", function ($scope) {

}]);