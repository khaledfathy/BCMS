
var App = angular.module('UTMSApp', ['ngRoute', 'uiGmapgoogle-maps', 'chieffancypants.loadingBar', 'ngAnimate']);

var connect = null;
App.config(['$routeProvider', "cfpLoadingBarProvider", function ($routeProvider, cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
    $routeProvider
    .when('/', { templateUrl: '/Areas/UTMS/Angular/StockUp/Index.html', controller: 'StockUpController' })

    .when('/StockUp', { templateUrl: '/Areas/UTMS/Angular/StockUp/Index.html', controller: 'StockUpController' })

    .when('/MarketCaster', { templateUrl: '/Areas/UTMS/Angular/MarketCaster/Index.html', controller: 'MarketCasterController' })

    .when('/BorsaGraphics', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/Index.html', controller: 'BorsaGraphicsController' })

    .when('/BcCounters', { templateUrl: '/Areas/UTMS/Angular/BC-Counters/Counters.html', controller: 'BC-CounterController' })

    .when('/BcIndicators', { templateUrl: '/Areas/UTMS/Angular/BC-Indicators/Indicators.html', controller: 'BcIndicatorsController' })

    .when('/MetaStock', { templateUrl: '/Areas/UTMS/Angular/MetaStock/MetaStock.html', controller: 'MetaStockController' })

    .when('/BorsaCloud', { templateUrl: '/Areas/UTMS/Angular/BorsaCloud/Index.html', controller: 'BorsaCloudController' })

    .when('/BorsaBreak', { templateUrl: '/Areas/UTMS/Angular/BorsaBreak/BorsaBreak.html', controller: 'BorsaBreakController' })

    .when('/MarketNews', { templateUrl: '/Areas/UTMS/Angular/BorsaBreak/MarketNews.html', controller: 'MarketNewsController' })

    .when('/Television', { templateUrl: '/Areas/UTMS/Angular/BorsaBreak/Television.html', controller: 'TelevisionController' })

    .when('/Magazines', { templateUrl: '/Areas/UTMS/Angular/BorsaBreak/Magazines.html', controller: 'MagazinesController' })

    .when('/Petrochemicals', { templateUrl: '/Areas/UTMS/Angular/Petrochemical/Petrochemical.html', controller: 'PetrochemicalsController' })

    .when('/investment', { templateUrl: '/Areas/UTMS/Angular/Investment/Investment.html', controller: 'InvestmentsController' })

    .when('/CompaniesMap', { templateUrl: '/Areas/UTMS/Angular/CompaniesMap/CompaniesMap.html', controller: 'CompaniesMapController' })

    .when('/CompanyCard', { templateUrl: '/Areas/UTMS/Angular/CompanyCard/Index.html', controller: 'CompanyCardController' })

    .when('/Knowledge', { templateUrl: '/Areas/UTMS/Angular/Knowledge/Knowledge.html', controller: 'KnowledgeController' })

    .when('/TradingTime', { templateUrl: '/Areas/UTMS/Angular/HelperPages/TradingTime.html', controller: 'TradingTimeController' })

    .when('/BorsaMarket', { templateUrl: '/Areas/UTMS/Angular/HelperPages/BorsaMarket.html', controller: 'BorsaMarketController' })

    .when('/GovernmentAgencies', { templateUrl: '/Areas/UTMS/Angular/HelperPages/GovernmentAgencies.html', controller: 'GovernmentAgenciesController' })

    .when('/Media', { templateUrl: '/Areas/UTMS/Angular/HelperPages/Media.html', controller: 'MediaController' })

    .when('/MediationCompanies', { templateUrl: '/Areas/UTMS/Angular/HelperPages/MediationCompanies.html', controller: 'MediationCompaniesController' })

    .when('/OtherEconomicsSources', { templateUrl: '/Areas/UTMS/Angular/HelperPages/OtherEconomicsSources.html', controller: 'OtherEconomicsSourcesController' })

    .when('/Regulators', { templateUrl: '/Areas/UTMS/Angular/HelperPages/Regulators.html', controller: 'RegulatorsController' })

    .when('/PageNotFound', { templateUrl: '/Areas/UTMS/Angular/PageNotFound.html', controller: 'PageNotFoundController' })

    .otherwise({
        redirectTo: '/PageNotFound'
    });

    connect = $.connection.mainHub;
    // Start connection
    $.connection.hub.start();
    connect.client.logoff = function () {
        $.connection.hub.stop();
        window.location.href = "/Account/LogOff";
    }

}]);

App.controller('MetaStockController',["$scope","Page", function ($scope,Page) {
    Page.setTitle('Meta Stock');
}]);

App.controller('BorsaBreakController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('استراحة | بورصة كابيتال');
}]);

App.controller('MarketNewsController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('أخبار السوق | بورصة كابيتال');
}]);

App.controller('TelevisionController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('تلفزيون | بورصة كابيتال');
}]);

App.controller('MagazinesController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('مـجـلات | بورصة كابيتال');
}]);


App.controller('InvestmentsController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('استثمارك فى سطر');
}]);

App.controller('CompanyCardController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('كروت الشركات');
}]);

App.controller('TradingTimeController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('أوقات التداول');
}]);

App.controller('BorsaMarketController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('سوق الأسهم');
}]);

App.controller('GovernmentAgenciesController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('الجهات الحكومية');
}]);

App.controller('MediaController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('الإعــلام');
}]);

App.controller('MediationCompaniesController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('شركات الوساطة');
}]);

App.controller('OtherEconomicsSourcesController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('مصادر إقتصادية اخرى');
}]);

App.controller('RegulatorsController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('الجهات الرقابية');
}]);

App.controller('PageNotFoundController', ["$scope", "Page", function ($scope, Page) {
    Page.setTitle('صفحة غير موجوده');
    $scope.content = null;
    var lang = getCookie('language');
    if (lang == 'en') {
        $scope.content = "Sorry the page you requested not found";
    } else {
        $scope.content = "عذراً ولكن الصفحة التى تبحث عنها غير موجودة";
    }
}]);


// Set page title service
App.factory('Page', function () {
    var title = 'بورصة كابيتال | UTMS';
    return {
        title: function () { return title; },
        setTitle: function (newTitle) { title = newTitle }
    };
});

App.controller('TitleController',["$scope","Page", function ($scope, Page) {
    $scope.Page = Page;
}])


