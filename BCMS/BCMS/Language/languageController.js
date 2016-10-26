/// <reference path="langApp.js" />
/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/jquery-1.10.2.js" />

MyApp.controller("languageController", function ($scope, $translate, $cookies) {
    //var lang = localStorage.getItem('language');

    // Retrieving a cookie
    var lang = $cookies.get('language');
    if (lang == 'en') {
        $scope.arabic = false;
    }
    else
        $scope.arabic = true;

    $scope.switchLanguage = function (langKey) {
        $translate.use(langKey);
       
        // Setting a cookie
        $cookies.put('language', langKey, { path: "/" });

        //localStorage.setItem('language', langKey);
        
        if (langKey == 'en') {
            $scope.arabic = false;
            // Remove Arabic CSS files
            $('link[href="/Materials/Ar/css/foundation.css"]').remove();
            $('link[href="/Materials/Ar/css/MainStyle.css"]').remove();
            $('link[href="/Materials/Ar/css/Inputs.css"]').remove();
            $('link[href="/Materials/Ar/Sliding/css/Sliding.css"]').remove();
            $('link[href="/Materials/Ar/MainMenu/css/component.css"]').remove();
            $('link[href="/Materials/Ar/MainMenu/css/default.css"]').remove();
            $('link[href="/Materials/Ar/MainMenu/css/css3.css"]').remove();
            $('link[href="/Materials/Ar/Slider/responsiveslides.css"]').remove();
            $('link[href="/Materials/Ar/css/login.css"]').remove();

            // Add English CSS files
            $('head').append('<link rel="stylesheet" href="/Materials/En/css/foundation.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/css/MainStyle.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/css/Inputs.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/Sliding/css/Sliding.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/Sliding/css/Sliding.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/MainMenu/css/component.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/MainMenu/css/css3.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/Slider/responsiveslides.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/En/css/login.css" type="text/css" />');

        }

        if (langKey == 'ar') {
            $scope.arabic = true;
            // Remove English CSS files
            $('link[href="/Materials/En/css/foundation.css"]').remove();
            $('link[href="/Materials/En/css/MainStyle.css"]').remove();
            $('link[href="/Materials/En/css/Inputs.css"]').remove();
            $('link[href="/Materials/En/Sliding/css/Sliding.css"]').remove();
            $('link[href="/Materials/En/MainMenu/css/component.css"]').remove();
            $('link[href="/Materials/En/MainMenu/css/default.css"]').remove();
            $('link[href="/Materials/En/MainMenu/css/css3.css"]').remove();
            $('link[href="/Materials/En/Slider/responsiveslides.css"]').remove();
            $('link[href="/Materials/En/css/login.css"]').remove();

            // Add Arabic CSS files
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/css/foundation.css"" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/css/MainStyle.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/css/Inputs.css"" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/Sliding/css/Sliding.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/MainMenu/css/component.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/MainMenu/css/default.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/MainMenu/css/css3.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/Slider/responsiveslides.css" type="text/css" />');
            $('head').append('<link rel="stylesheet" href="/Materials/Ar/css/login.css" type="text/css" />');

        }
    }

});