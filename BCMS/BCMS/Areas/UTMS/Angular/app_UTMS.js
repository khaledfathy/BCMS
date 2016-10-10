
var App = angular.module('UTMSApp', ['ngRoute', 'uiGmapgoogle-maps']);

App.config(['$routeProvider', function ($routeProvider) {
 
    $routeProvider

    .when('/', { templateUrl: '/Areas/UTMS/Angular/BorsaCloud/Index.html', controller: 'BorsaCloudController' })

    .when('/StockUp', { templateUrl: '/Areas/UTMS/Angular/StockUp/Index.html', controller: 'StockUpController' })

    .when('/MarketCaster', { templateUrl: '/Areas/UTMS/Angular/MarketCaster/Index.html', controller: 'MarketCasterController' })

    .when('/BorsaGraphics', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/Index.html', controller: 'BorsaGraphicsController' })

    .when('/Analyses/:CategoryId', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/Analyses.html', controller: 'AnalysesController' })

    .when('/AnalysesDetails/:KindId', { templateUrl: '/Areas/UTMS/Angular/BorsaGraphics/AnalysesDetails.html', controller: 'AnalysesDetailsController' })

    .when('/ChartDiv/:ChartId', { templateUrl: '/UTMS/BorsaGraphics/ChartDiv', controller: 'ChartDivController' })

    //.when('/BorsaGraphics', { templateUrl: '/UTMS/BorsaGraphics/Index', controller: 'BorsaGraphicsController' })

    //.when('/Analyses/:CategoryId', { templateUrl: '/UTMS/BorsaGraphics/Analyses', controller: 'AnalysesController' })

    //.when('/AnalysesDetails/:KindId', { templateUrl: '/UTMS/BorsaGraphics/AnalysesDetails', controller: 'AnalysesDetailsController' })





    .when('/BorsaCloud', { templateUrl: '/Areas/UTMS/Angular/BorsaCloud/Index.html', controller: 'BorsaCloudController' })

    


    .when('/GreenRed', { templateUrl: '/UTMS/GreenRed/Index', controller: 'GreenRedController' })

    .when('/MetaStock', { templateUrl: '/UTMS/MetaStock/Index', controller: 'MetaStockController' })

    .when('/Trader', { templateUrl: '/UTMS/Trader/Index', controller: 'TraderController' })

    .when('/bullsAndBears', { templateUrl: '/UTMS/bullsAndBears/Index', controller: 'bullsAndBearsController' })

    .when('/Petrochemicals', { templateUrl: '/UTMS/Petrochemicals/Index', controller: 'PetrochemicalsController' })

    .when('/CompaniesMap', { templateUrl: '/UTMS/CompaniesMap/Index', controller: 'CompaniesMapController' })

    .when('/Knowledge', { templateUrl: '/UTMS/Knowledge/Index', controller: 'KnowledgeController' })

    .when('/investment', { templateUrl: '/UTMS/Investments/Index', controller: 'InvestmentsController' })

    .when('/BcCounters', { templateUrl: '/UTMS/BcCounters/Index', controller: 'BcCountersController' })

    .when('/BcIndicators', { templateUrl: '/UTMS/BcIndicators/Index', controller: 'BcIndicatorsController' })

    .when('/MarketCaster2', { templateUrl: '/UTMS/MarketCaster/MarketCaster2', controller: 'MarketCaster2Controller' })

    .when('/MarketCaster3', { templateUrl: '/UTMS/MarketCaster/MarketCaster3', controller: 'MarketCaster3Controller' })

    .when('/BorsaBreak', { templateUrl: '/UTMS/BorsaBreak/Index', controller: 'BorsaBreakController' })

    

    .when('/TradingTime', { templateUrl: '/UTMS/HelpTools/TradingTime', controller: 'TradingTimeController' })

    .when('/CompanyCard', { templateUrl: '/UTMS/CompanyCard/Card', controller: 'CompanyCardController' })
        //.when("/signalr/hubs/", { templateUrl: "/signalr/hubs/", controller:"signalr" })
    .when('/WorldEconomy', {
        templateUrl: '/UTMS/WorldEconomy/Index',
        controller: 'WorldEconomyController'
    })

    
    //.when('/AboutUs', { templateUrl: '/Home/Index/#AboutUs', controller: 'AboutUsController' })
    .otherwise({
        redirectTo: '/'
    });
}]);



//App.controller('ChartDivController', function ($scope) {
//    $scope.loading = true;
//    DoLoading();
//    $scope.ChartId = $routeParams.ChartId;
//    $http({
//        url: "/UTMS/BorsaGraphics/ChartDiv",
//        method: 'GET',
//        params: { id: $scope.ChartId }
//    }).success(function (data) {
//        $scope.Chart = data;
//        $scope.loading = false;
//    }).error(function () {
//        alert("error");
//        $scope.loading = false;
//    });
//});

App.controller('GreenRedController', function ($scope) {

});

App.controller('WorldEconomyController', function ($scope) {

});

App.controller('MetaStockController', function ($scope) {

});

App.controller('TraderController', function ($scope) {

});

App.controller('bullsAndBearsController', function ($scope) {

});

App.controller('PetrochemicalsController', ["$scope", "$http", function ($scope, $http) {
    $scope.loading = true;
    DoLoading();
    $http.get("/UTMS/Petrochemicals/GetAllPetrochemicals").success(function (data) {
        $scope.MyData = data;
        $scope.loading = false;
    }).error(function (error) {
        alert(error);
        $scope.loading = false;
    });
}]);

App.controller('CompanyCardController', function ($scope) {

});

App.controller('CompaniesMapController', function ($scope) {

    $scope.map = { center: { latitude: 24.3269853, longitude: 45.0858763 }, zoom: 6 };

    $scope.markers = [
        { 'latitude': 24.4564278, 'longitude': 39.6433692, 'message': 'dd' },
        { 'latitude': 24.797819, 'longitude': 46.722355, 'message': 'ee' }
    ];
});

App.controller('KnowledgeController', ["$scope", "$http", function ($scope, $http) {
    $scope.loading = true;
    DoLoading();

    $http.get("/UTMS/Knowledge/GetAllKnowledge").success(function (data) {

        $scope.knowledges = data;
        console.log(data);
        $scope.loading = false;
    }).error(function (error) {
        alert(error);
        $scope.loading = false;
    });

    $scope.status = {
        isCustomHeaderOpen: false,
        isFirstOpen: true,
        isFirstDisabled: false
    };
}]);

App.controller('InvestmentsController', function ($scope) {

});

App.controller('BcCountersController', function ($scope) {
    $scope.loading = true;
    DoLoading();
    //  $scope.loading = false;

});

App.controller('BcIndicatorsController', function ($scope) {


});

App.controller('MarketCaster2Controller', function ($scope) {


});

App.controller('MarketCaster3Controller', function ($scope) {


});

App.controller('BorsaBreakController', function ($scope) {

});

App.controller('AboutUsController', function ($scope) {

});

App.controller('TradingTimeController', function ($scope) {

});

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
