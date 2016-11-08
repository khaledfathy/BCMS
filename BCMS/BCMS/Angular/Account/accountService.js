/// <reference path="../anonymousApp.js" />

MyApp.factory("registerationService", function ($http, $q) {
    var fac = {};
    fac.saveFormData = function (data, lang) {
        var defer = $q.defer();
        $http({
            url: '/Account/Register',
            method: 'POST',
            data: { "model": data, "language": lang },
            headers: { 'content-type': 'application/json' }
        }).success(function (d) {
            defer.resolve(d);
        }).error(function (e) {
            window.location.href = "/Home/Error";
            defer.reject(e);
        });
        return defer.promise;
    }
    return fac;
})