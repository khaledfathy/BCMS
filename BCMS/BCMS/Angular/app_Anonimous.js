/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/angular.js" />

var MyApp = angular.module('MyApp', ['ngRoute', 'mm.foundation', 'pascalprecht.translate', 'chieffancypants.loadingBar', 'ngAnimate']);

MyApp.config(["$routeProvider", "$locationProvider", "cfpLoadingBarProvider", function ($routeProvider, $locationProvider, cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;

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
    .when('/Profile', {
        templateUrl: '/Angular/Account/Profile.html',
        controller: 'ProfileController'
    })
    .when('/ChangePassword', {
        templateUrl: '/Angular/Account/ChangePassword.html',
        controller: 'ChangePasswordController'
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
        templateUrl: '/Angular/Home/AboutUs.html',
        controller: 'AboutUsController'
    })
    .when('/BCWord', {
        templateUrl: '/Angular/Home/BCWord.html',
        controller: 'BCWordController'
    })
    .when('/AboutSaudi', {
        templateUrl: '/Angular/Home/AboutSaudi.html',
        controller: 'AboutSaudiController'
    })
    .when('/Demo', {
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
    }).when('/PageNotFound', {
        templateUrl: '/Angular/PageNotFound.html',
        controller: 'PageNotFoundController'
    })
    .otherwise({
        redirectTo: '/PageNotFound'
    });
}])

/**************************************************** Controllers ***********************************************************/

MyApp.controller('HomeController', ["$scope", "Page", function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Home | Borsa Capital')
    } else {
        Page.setTitle('الرئيسية | بورصة كابيتال')
    }
    $scope.bc = 'bc';
    $scope.ourServices = 'ourServices';
    $scope.education = 'education';
    $scope.entertainment = 'entertainment';

}]);

MyApp.controller('AboutUsController', ["$scope", "Page", function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('About us | Borsa Capital')
    } else {
        Page.setTitle('نبذه عنا | بورصة كابيتال')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('BCWordController', ["$scope", "Page", function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Borsa Capital Word')
    } else {
        Page.setTitle('كلمة بورصة كابيتال')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('AboutSaudiController', ["$scope", "Page", function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('About Saudi Arabia')
    } else {
        Page.setTitle('نبذه عن المملكة العربية السعودية')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('DemoController', ["$scope", "Page", function ($scope, Page) {

    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Demo | Borsa Capital')
    } else {
        Page.setTitle('حساب تجريبى | بورصة كابيتال')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('PartnersController', ["$scope", "Page", function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Our Partners | Borsa Capital')
    } else {
        Page.setTitle('شركاؤنا | بورصة كابيتال')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('PyramidServicesController', ["$scope", "Page", function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Pyramid Services')
    } else {
        Page.setTitle('هرم الخدمات')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('SayingsOfWiseController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Sayings of wise')
    } else {
        Page.setTitle('من أقوال الحكماء')
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('AdviceController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Investment advices');
    } else {
        Page.setTitle('نصائح إستثمارية');
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('TerminologyController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Terminology | Borsa Capital');
    } else {
        Page.setTitle('المصطلحات | بورصة كابيتال');
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('GamesController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Games | Borsa Capital');
    } else {
        Page.setTitle('ألعاب ترفيهية | بورصة كابيتال');
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('RelaxingController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Relaxing videos');
    } else {
        Page.setTitle('فيديوهات الاسترخاء');
    }
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
}]);

MyApp.controller('PageNotFoundController', function ($scope, Page) {
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Page not found');
    } else {
        Page.setTitle('الصفحة غير موجودة');
    }
    $scope.content = null;
    var lang = getCookie('language');
    if (lang == 'en') {
        $scope.content = "Sorry the page you requested not found";
    } else {
        $scope.content = "عذراً ولكن الصفحة التى تبحث عنها غير موجودة";
    }
})

// Set page title service
MyApp.factory('Page', function () {
    var lang = getCookie('language');
    var title = '';
    if (lang == 'en') {
        title = 'Borsa Capital | Welcome';
    } else {
        title = 'بورصة كابيتال | مرحباً';
    }
    return {
        title: function () { return title; },
        setTitle: function (newTitle) { title = newTitle }
    };
});
// Set page title controller
MyApp.controller('TitleController', function ($scope, Page) {
    $scope.Page = Page;
})



