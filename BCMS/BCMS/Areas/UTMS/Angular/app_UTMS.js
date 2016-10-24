
var App = angular.module('UTMSApp', ['ngRoute', 'uiGmapgoogle-maps', 'chieffancypants.loadingBar', 'ngAnimate']);

var connect = null;
App.config(['$routeProvider', "cfpLoadingBarProvider", function ($routeProvider, cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
    $routeProvider
    .when('/', { templateUrl: '/Areas/UTMS/Angular/BorsaCloud/Index.html', controller: 'BorsaCloudController' })

    .when('/StockUp', { templateUrl: '/Areas/UTMS/Angular/StockUp/Index.html', controller: 'StockUpController' })

    .when('/MarketCaster', { templateUrl: '/Areas/UTMS/Angular/MarketCaster/Index.html', controller: 'MarketCasterController' })

    .when('/BorsaGraphics', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/Index.html', controller: 'BorsaGraphicsController' })

    .when('/Analyses/:CategoryId', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/Analyses.html', controller: 'AnalysesController' })

    .when('/AnalysesDetails/:KindId', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/AnalysesDetails.html', controller: 'AnalysesDetailsController' })

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

    .otherwise({ redirectTo: '/' });


    connect = $.connection.mainHub;
    $.connection.hub.start();
    connect.client.logoff = function () {
        
        $.connection.hub.stop();
        window.location.href = "/Account/LogOff";
    }


}]);

App.controller('CompanyCardController', function ($scope) {

});


