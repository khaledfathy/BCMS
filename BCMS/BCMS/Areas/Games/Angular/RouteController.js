var MyApp = angular.module('MyApp', ['ngRoute']);
MyApp.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '/Home/Home',
        controller: 'HomeController'
    })
    .when('/Login', {
        templateUrl: '/Account/Login',
        controller: 'LoginController'
    })
    .when('/Register', {
        templateUrl: '/Account/Registration',
        controller: 'RegistrationController'
    })
    .when('/AdminstrationMessage', {
        templateUrl: 'AdminstrationMessage.html',
        controller: 'AdminstrationMessageController'
    })
    .when('/Forgotpassword', {
        templateUrl: '/Account/Forgotpassword',
        controller: 'ForgotpasswordController'
    })
    .when('/Resetpassword', {
        templateUrl: '/Account/ResetPassword',
        controller: 'ResetpasswordController'
    })
    .otherwise({
        redirectTo: '/'
    });
    //$locationProvider.html5Mode(true).hashPrefix('!');
}]);

MyApp.controller('HomeController', ["$scope", function ($scope) {

}]);

MyApp.controller('LoginController', ["$scope", function ($scope) {

}]);

MyApp.controller('RegistrationController', ["$scope", function ($scope) {

}]);

MyApp.controller('AdminstrationMessageController', ["$scope", function ($scope) {

}]);

MyApp.controller('ForgotpasswordController', ["$scope", function ($scope) {

}]);

MyApp.controller('ResetpasswordController', ["$scope", function ($scope) {

}]);