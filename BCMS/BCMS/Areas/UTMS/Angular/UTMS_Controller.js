/// <reference path="../app_UTMS.js" />

App.controller('BorsaCloudController', ["$scope", "$http","Page", function ($scope, $http,Page) {
    Page.setTitle('بورصة كلاود');
    //check to push  old data to (CategoriesOld) just first time run page Borsa Cloud
    var check = false;
    // categories before change
    var CategoriesOld = [];
    // categories After change
    var CategoriesNew = [];
    //The oldest values in Categories
    var CategoriesOldest = [];
    $(function () {
        var notifications = $.connection.MessagesHub;
        // when data changeing update automaticly
        notifications.client.updateMessages = function () {
            getAllMessages();
            //connection.hub stop and start to avoiding a problem in repeat connection
            //when refresh or open same page
            $.connection.hub.stop();
            $.connection.hub.start();
        };
        $.connection.hub.start().done(function () {
            check = false;
            getAllMessages();

        }).fail(function (e) {
            alert(e);
        });
    });
    function getAllMessages() {
        var SectorAndCategory = $('#SectorAndCategory');
        $http({
            url: '/BorsaCloud/GetMessages',
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function (result) {
            if (result == "Error") {
                window.location.href = "/Home/Error";
            } else {
                SectorAndCategory.empty().append(result);
                $("#loadingArea").hide();
                $(".row").show();
                if (check == false) {
                    // convert old data before change to array CategoriesOld
                    function ConvertToArray(tag) {
                        var a = [];
                        for (var i = 0; i < tag.length; i++) {
                            a.push(tag[i].innerHTML);
                        }
                        CategoriesOld = a;
                    }
                    ConvertToArray($("#SectorAndCategory li").toArray());
                }
                check = true;
                $('#SectorAndCategory').trigger('contentchanged');
            }


        }).error(function () {
            window.location.href = "/Home/Error";

        });
    }
    $('#SectorAndCategory').bind('contentchanged', function () {
        // convert new  data after change to array CategoriesNew
        function ConvertToArray(tag) {
            var a = [];
            for (var i = 0; i < tag.length; i++) {
                a.push(tag[i].innerHTML);
            }
            CategoriesNew = a;
        }
        ConvertToArray($("#SectorAndCategory li").toArray());

        for (var x = 1; x < CategoriesNew.length; x++) {
            if ((CategoriesNew[x] - CategoriesOld[x]) < 0) {
                if (CategoriesOld[x] - CategoriesOldest[x] < 0) {
                    $("#SectorAndCategory li:nth-child(" + x + ")").css("color", "#ec0a0a");
                    $("#SectorAndCategory li:nth-child(" + x + ")").addClass("HomePicAnimated");
                }
                    //when condition Not achieved
                else {
                    $("#SectorAndCategory li:nth-child(" + x + ")").css("color", "#ec0a0a");
                }
            }
            else if ((CategoriesNew[x] - CategoriesOld[x]) > 0) {
                if (CategoriesOld[x] - CategoriesOldest[x] > 0) {
                    $("#SectorAndCategory li:nth-child(" + x + ")").css("color", "rgb(155, 218, 9)");
                    $("#SectorAndCategory li:nth-child(" + x + ")").addClass("HomePicAnimated");
                }
                    //when condition Not achieved
                else {
                    $("#SectorAndCategory li:nth-child(" + x + ")").css("color", "rgb(155, 218, 9)");
                }
            }
            else {
                $("#SectorAndCategory li:nth-child(" + x + ")").css("color", "#e7e7e7");
            }
        }

        // empty the older array and set old array
        CategoriesOldest = [];
        CategoriesOldest = CategoriesOld;
        // empty the old array and set new array
        CategoriesOld = [];
        CategoriesOld = CategoriesNew;
        //empty new array
        CategoriesNew = [];
    });


}]);

App.controller('MarketCasterController',["$scope","$http","Page", function ($scope, $http, Page) {
    Page.setTitle('ماركت كاستر');
    $(".row").hide();
    // last market caster
    var marketableold = [];
    // market caster At the current moment
    var marketablenew = [];
    //The oldest values in market caster
    var marketcasterstat = [];
    //check to push  old data to (marketableold) just first time run page market caster
    var check = false;
    $(function () {
        var notifications = $.connection.MessagesHub;
        // when data changeing update automaticly
        notifications.client.updateMessages = function () {
            getAllMessages();
            //connection.hub stop and start to avoiding a problem in repeat connection
            //when refresh or open same page
            $.connection.hub.stop();
            $.connection.hub.start();
        };
        $.connection.hub.start().done(function () {
            check = false;
            //function getting data from database
            getAllMessages();
        }).fail(function (e) {
            alert(e);
        });
    });

    function getAllMessages() {
        var tbl = $('#mrkcaster');
        $http.get('/MarketCaster/GetMessages').success(function (result) {
            if (result == "Error") {
                window.location.href = "/Home/Error";
            }
            else {
                //clean table market caster and append new data from partial view (_MessagesList)
                tbl.empty().append(result);
                $("#loadingArea").hide();
                $(".row").show();
                if (check == false) {
                    // push cells market caster table to Array for current market values to  marketableold
                    var myTableArray = [];
                    $("#mrkcaster tr").each(function () {
                        var arrayOfThisRow = [];
                        var tableData = $(this).find('td');
                        if (tableData.length > 0) {
                            tableData.each(function () { arrayOfThisRow.push($(this).text()); });
                            myTableArray.push(arrayOfThisRow);
                        }
                        marketableold = myTableArray;
                    });
                }
                //trigger fire when data changeing from database
                $('#mrkcaster').trigger('contentchanged');
                check = true;
            }
        }).error(function () {
            window.location.href = "/Home/Error";
        });
    }

    $('#mrkcaster').bind('contentchanged', function () {
        //puch market caster table for this moment to array to marketablenew
        var myTableArray = [];
        $("#mrkcaster tr").each(function () {
            var arrayOfThisRow = [];
            var tableData = $(this).find('td');
            if (tableData.length > 0) {
                tableData.each(function () { arrayOfThisRow.push($(this).text()); });
                myTableArray.push(arrayOfThisRow);
            }
            marketablenew = myTableArray;
        });

        // compare with 3 araays
        // first change  marketcasterstat is null
        for (var x = 0; x < marketablenew.length; x++) {
            for (var i = 2; i < 15; i++) {
                if ((marketablenew[x][i] - marketableold[x][i]) < 0) {
                    if (marketableold[x][i] - marketcasterstat[x][i] < 0) {
                        //make background color for 1 sec and remove it
                        var ss = document.getElementById("mrkcaster").rows[x + 1].cells[i];
                        ss.style.color = "red";
                        ss.style.backgroundColor = "#540707";
                        setTimeout(function () {
                            var $el = $("#mrkcaster tr td");
                            $el.css("background", "none");
                        }, 1000);
                    }
                        //when condition Not achieved
                    else
                        document.getElementById("mrkcaster").rows[x + 1].cells[i].style.color = "red";
                }
                else if ((marketablenew[x][i] - marketableold[x][i]) > 0) {
                    if (marketableold[x][i] - marketcasterstat[x][i] > 0) {
                        //make background color for 1 sec and remove it
                        var ss = document.getElementById("mrkcaster").rows[x + 1].cells[i];
                        ss.style.color = "rgb(0, 249, 92)";
                        ss.style.backgroundColor = "#174811";
                        setTimeout(function () {
                            var $el = $("#mrkcaster tr td");
                            $el.css("background", "none");
                        }, 1000);
                    }
                        //when condition Not achieved
                    else {
                        document.getElementById("mrkcaster").rows[x + 1].cells[i].style.color = "rgb(0, 249, 92)";
                    }
                }
                else {
                    document.getElementById("mrkcaster").rows[x + 1].cells[i].style.color = "#5DC0E0";
                }
            }
        }

        // empty the older array and set old array
        marketcasterstat = [];
        marketcasterstat = marketableold;
        // empty the old array and set new array
        marketableold = [];
        marketableold = marketablenew;
        //empty new array
        marketablenew = [];
    });
}]);

App.controller('StockUpController',["$scope","Page", function ($scope,Page) {
    Page.setTitle('الملخص اليومى');
    // First tabs
    $scope.gotoAnchor = function (id) {
        for (i = 0; i <= 6; i++) {
            $("#" + i + "").removeClass("active");
            $("#li" + i + "").removeClass("active");
        }
        $("#" + id + "").addClass("active");
        $("#li" + id + "").addClass("active");

    };
    // Second tabs
    $scope.gotoAnchorShare = function (id) {
        for (i = 7; i <= 9; i++) {
            $("#" + i + "").removeClass("active");
            $("#li" + i + "").removeClass("active");
        }
        $("#" + id + "").addClass("active");
        $("#li" + id + "").addClass("active");
    }
}]);

App.controller('BorsaGraphicsController', ["$scope", "$http", "$sce","Page", function ($scope, $http, $sce,Page) {
    Page.setTitle('بورصة جرافيكس');
    $scope.ChartAnalysesKind = null;
    // Get Chart Categories request
    $http.get("/UTMS/BorsaGraphics/GetAllChartCategories")
        .success(function (data) {
            if (data == "Error") {
                window.location.href = "/Home/Error";
            }
            else {
                $scope.ChartCategory = data;
            }
        }).error(function () {
            window.location.href = "/Home/Error";
        });
    // Get Chart Analyses Kind with first category as initial value 
    $http({
        url: "/UTMS/BorsaGraphics/GetAllChartAnalysesKind",
        method: 'GET',
        params: { id: 1 }
    }).success(function (data) {
        if (data == "Error") {
            window.location.href = "/Home/Error";
        }
        else {
            $scope.ChartAnalysesKind = data;
            $scope.ChartAnalysesKind[0].active = true;
        }
    }).error(function () {
        window.location.href = "/Home/Error";
    });
    
    // First Chart url to run on first page request
    $scope.url = $sce.trustAsResourceUrl('/UTMS/BorsaGraphics/ChartDiv/1');

    // Get selected Chart analyses kind
    $scope.DisplayCategory = function (catId) {
        $http({
            url: "/UTMS/BorsaGraphics/GetAllChartAnalysesKind",
            method: 'GET',
            params: { id: catId }
        }).success(function (data) {
            if (data == "Error") {
                window.location.href = "/Home/Error";
            }
            else {
                $scope.ChartAnalysesKind = data;
                $scope.ChartAnalysesKind[0].active = true;
            }
        }).error(function () {
            window.location.href = "/Home/Error";
        });
        for (i = 1; i <= 6; i++) {
            angular.element("#" + i + "").removeClass("Active");
        }
        angular.element("#" + catId + "").addClass("Active");
    }

    // Get selected chart
    $scope.DisplayChart = function (ChartId) {
        $scope.url = $sce.trustAsResourceUrl('/UTMS/BorsaGraphics/ChartDiv/' + ChartId + '');
        $('.highcharts-Sub>li>a.Active').removeClass('Active');
        angular.element("#chart" + ChartId + "").addClass("Active");
    }

    // Expand selected chart analyses kind
    $scope.showChilds = function (index) {
        $scope.ChartAnalysesKind[index].active = true;
        $(".cakli>a.Active").removeClass("Active");
        angular.element("#cak" + index + "").addClass("Active");
        collapseAnother(index);
    };
    // Collapse other chart analyses kind
    var collapseAnother = function (index) {
        for (var i = 0; i < $scope.ChartAnalysesKind.length; i++) {
            if (i != index) {
                $scope.ChartAnalysesKind[i].active = false;
            }
        }
    };

}]);

App.controller('BC-CounterController',["$scope","$http","Page", function ($scope, $http, Page) {
    Page.setTitle('عدادات بورصة كابيتال');

    $(".RegisterWrapper").hide();

    $("#ddlMarkets").change(function () {
        var selectedMarket = $("#ddlMarkets :selected").val();
        DrowChart(selectedMarket);
        DrowChartOut(selectedMarket);
        DrowChartCompin(selectedMarket);
    });

    $http.get("/UTMS/BcCounters/selectAllMarkets").success(function (result) {
        if (result == "Error") {
            window.location.href = "/Home/Error";
        }
        else {
            $("#ddlMarkets").html("");
            for (var i = 0, count = result.length; i < result.length; i++) {
                $("#ddlMarkets").append("<option value=" + result[i].CODE + ">" + result[i].NAME + "</option>")
            }
            var FirstCode = $("#ddlMarkets option:first").val();
            DrowChart(FirstCode);
            DrowChartOut(FirstCode);
            DrowChartCompin(FirstCode);
        }
    }).error(function (e) {
        window.location.href = "/Home/Error";
    });

    function DrowChart(code) {
        $http.get("/UTMS/BcCounters/selectMarketData", { params: { code: code } }).success(function (result) {
            if (result == "Error") {
                window.location.href = "/Home/Error";
            }
            else {
                //console.log('first Code is ' + code);
                var CompanyNames = [];
                var CashFlowInValue = [];
                var CashFlowOutValue = [];

                for (var i = 0; i < result.length; i++) {
                    CompanyNames.push(result[i].Name);
                    CashFlowInValue.push(result[i].CASHFLOWIN);
                    CashFlowOutValue.push(result[i].CASHFLOWOUT)
                }
                var nr = CashFlowInValue;
                //console.log('nr  ' + nr);
                var charts = new Highcharts.Chart({

                    chart: {
                        type: 'gauge',
                        alignTicks: false,
                        plotBackgroundColor: null,
                        plotBackgroundImage: null,
                        plotBorderWidth: 0,
                        plotShadow: false,
                        renderTo: 'bccounter'
                    },

                    title: {
                        text: ''
                    },
                    pane: {
                        startAngle: -150,
                        endAngle: 150,
                        background: [{
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                    [0, '#DDD'],
                                    [1, '#333']
                                ]
                            },
                            borderWidth: 0,
                            outerRadius: '109%'
                        }, {
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                    [0, '#333'],
                                    [1, '#DDD']
                                ]
                            },
                            borderWidth: 1,
                            outerRadius: '107%'
                        }, {
                            // default background
                        }, {
                            backgroundColor: '#DDD',
                            borderWidth: 0,
                            outerRadius: '105%',
                            innerRadius: '103%'
                        }]
                    },
                    credits: {

                        text: 'Borsa Capital',
                        href: 'http://borsacapital.com'
                    },
                    yAxis: [{
                        min: 0,
                        max: 100000,
                        lineColor: '#339',
                        tickColor: '#339',
                        minorTickColor: '#339',
                        offset: -25,
                        lineWidth: 2,
                        labels: {
                            distance: -20,
                            rotation: 'auto',
                            formatter: function () {
                                return +this.value / 1000 + ' ' + 'M SR';
                            }
                        },
                        tickLength: 5,
                        minorTickLength: 5,
                        endOnTick: false
                    }, {
                        min: 0,
                        max: 100000,
                        tickPosition: 'outside',
                        lineColor: '#933',
                        lineWidth: 2,
                        minorTickPosition: 'outside',
                        tickColor: '#933',
                        minorTickColor: '#933',
                        tickLength: 5,
                        minorTickLength: 5,
                        labels: {
                            distance: 12,
                            rotation: 'auto',
                            formatter: function () {
                                return +this.value / 1000 + ' ' + 'M SR';
                            }
                        },
                        offset: -20,
                        endOnTick: false
                    }],
                    series: [{
                        name: 'M',
                        data: [nr],
                        dataLabels: {
                            borderWidth: 1,
                            shadow: false,
                            useHTML: true,
                            padding: 4,

                            backgroundColor: {
                                linearGradient: {
                                    x1: 0,
                                    y1: 0,
                                    x2: 0,
                                    y2: 1
                                },
                                stops: [
                                    [0, '#DDD'],
                                    [1, '#333']
                                ]
                            }
                        }
                    }],
                    tooltip: {
                        //enabled: true,
                        backgroundColor: 'none',
                        borderWidth: 0,
                        shadow: false,
                        useHTML: true,
                        padding: 4,
                        formatter: function () {
                            $('#bccounter').hover(function () {
                                $('#tooltipChashFlowIn').toggle().html('السيولة الداخلة<br> ' + nr);
                            });
                        }
                    }
                    // Add some life

                    
                })
            }

        }).error(function (xhr, status, error) {
            window.location.href = "/Home/Error";
        })
    }

    function DrowChartOut(code) {
        $http.get("/UTMS/BcCounters/selectMarketData", { params: { code: code } }).success(function (result) {
            if (result == "Error") {
                window.location.href = "/Home/Error";

            }
            else {


                //console.log('first Code is ' + code);
                var CompanyNames = [];
                var CashFlowInValue = [];
                var CashFlowOutValue = [];

                for (var i = 0; i < result.length; i++) {
                    CompanyNames.push(result[i].Name);
                    CashFlowInValue.push(result[i].CASHFLOWIN);
                    CashFlowOutValue.push(result[i].CASHFLOWOUT)
                }
                var nr = CashFlowOutValue;
                //console.log('nr  ' + nr);
                //console.log('Company name ' + CompanyNames[0]);
                var charts = new Highcharts.Chart({

                    chart: {
                        type: 'gauge',
                        alignTicks: false,
                        plotBackgroundColor: null,
                        plotBackgroundImage: null,
                        plotBorderWidth: 0,
                        plotShadow: false,
                        renderTo: 'bccounter2'
                    },

                    title: {
                        text: ''
                    },
                    pane: {
                        startAngle: -150,
                        endAngle: 150,
                        background: [{
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                    [0, '#DDD'],
                                    [1, '#333']
                                ]
                            },
                            borderWidth: 0,
                            outerRadius: '109%'
                        }, {
                            backgroundColor: {
                                linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                                stops: [
                                    [0, '#333'],
                                    [1, '#DDD']
                                ]
                            },
                            borderWidth: 1,
                            outerRadius: '107%'
                        }, {
                            // default background
                        }, {
                            backgroundColor: '#DDD',
                            borderWidth: 0,
                            outerRadius: '105%',
                            innerRadius: '103%'
                        }]
                    },
                    credits: {

                        text: 'Borsa Capital',
                        href: 'http://borsacapital.com'
                    },
                    yAxis: [{
                        min: 0,
                        max: 100000,
                        lineColor: '#339',
                        tickColor: '#339',
                        minorTickColor: '#339',
                        offset: -25,
                        lineWidth: 2,
                        labels: {
                            distance: -20,
                            rotation: 'auto',
                            formatter: function () {
                                return +this.value / 1000 + ' ' + 'M SR';
                            }

                        },
                        tickLength: 5,
                        minorTickLength: 5,
                        endOnTick: false
                    }, {
                        min: 0,
                        max: 100000,
                        tickPosition: 'outside',
                        lineColor: '#933',
                        lineWidth: 2,
                        minorTickPosition: 'outside',
                        tickColor: '#933',
                        minorTickColor: '#933',
                        tickLength: 5,
                        minorTickLength: 5,
                        labels: {
                            distance: 12,
                            rotation: 'auto',
                            formatter: function () {
                                return +this.value / 100 + ' ' + 'M SR';
                            }
                        },
                        offset: -20,
                        endOnTick: false
                    }],

                    series: [{
                        name: 'Speed',
                        data: [nr],
                        dataLabels: {
                            borderWidth: 1,
                            shadow: false,
                            useHTML: true,
                            padding: 4,

                            backgroundColor: {
                                linearGradient: {
                                    x1: 0,
                                    y1: 0,
                                    x2: 0,
                                    y2: 1
                                },
                                stops: [
                                    [0, '#DDD'],
                                    [1, '#333']
                                ]
                            }
                        },
                        tooltip: {
                            valueSuffix: ' '
                        }
                    }],

                    tooltip: {
                        backgroundColor: 'none',
                        borderWidth: 0,
                        shadow: false,
                        useHTML: true,
                        padding: 4,
                        formatter: function () {
                            $('#bccounter2').hover(function () {
                                $('#tooltipChashFlowOut').toggle().html('السيولة الخارجة<br> ' + nr);
                            });
                        }
                    }
                })

            }

        })
        .error(function (xhr, status, error) {
            window.location.href = "/Home/Error";
        })
    }

    function DrowChartCompin(code) {
        $http.get("/UTMS/BcCounters/selectMarketData", { params: { code: code } }).success(function (result) {
            if (result == "Error") {
                window.location.href = "/Home/Error";

            }
            else {
                //console.log('first Code is ' + code);
                var CompanyNames = [];
                var CashFlowInValue = [];
                var CashFlowOutValue = [];
                $("#loadingArea").hide();
                $(".RegisterWrapper").show();

                for (var i = 0; i < result.length; i++) {
                    CompanyNames.push(result[i].Name);
                    CashFlowInValue.push(result[i].CASHFLOWIN);
                    CashFlowOutValue.push(result[i].CASHFLOWOUT)
                }
                var nr = CashFlowOutValue;
                //console.log('nr  ' + nr);
                var gaugeOptions = {
                    chart: {
                        type: 'solidgauge'
                    },
                    title: null,
                    pane: {
                        center: ['50%', '85%'],
                        size: '140%',
                        startAngle: -90,
                        endAngle: 90,
                        background: {
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                            innerRadius: '60%',
                            outerRadius: '100%',
                            shape: 'arc'
                        }
                    },
                    tooltip: {
                        backgroundColor: 'none',
                        borderWidth: 0,
                        shadow: false,
                        useHTML: true,
                        padding: 4,
                        formatter: function () {
                            $('#container-speed').hover(function () {
                                $('#tooltip').toggle().html('صافي السيولة<br> ' + (CashFlowInValue - CashFlowOutValue));
                            });
                        }
                    },
                    yAxis: {
                        stops: [
                            [0.1, '#55BF3B'], // green
                            [0.5, '#DDDF0D'], // yellow
                            [0.9, '#DF5353'] // red
                        ],
                        lineWidth: 0,
                        minorTickInterval: null,
                        tickPixelInterval: 400,
                        tickWidth: 0,
                        title: {
                            y: -70
                        },
                        labels: {
                            y: 16
                        }
                    },

                    plotOptions: {
                        solidgauge: {
                            dataLabels: {
                                y: 5,
                                borderWidth: 0,
                            }
                        }
                    }
                    ,
                    credits: {
                        text: 'Borsa Capital',
                        href: 'http://borsacapital.com'
                    },
                };
                var ch1 = new Highcharts.Chart(Highcharts.merge(gaugeOptions, {
                    chart: {
                        renderTo: 'container-speed'
                    },
                    yAxis: {
                        min: 0,
                        max: 100000,
                        title: {
                            text: 'السيولة الخارجة'
                        }
                    },
                    series: [{
                        name: 'الكمية',
                        data: [CashFlowOutValue / 100],
                        borderWidth: 1,
                        shadow: false,
                        useHTML: true,
                        padding: 0,
                        backgroundColor: {
                            linearGradient: {
                                x1: 0,
                                y1: 0,
                                x2: 0,
                                y2: 1
                            },
                            stops: [
                                [0, '#DDD'],
                                [1, '#333']
                            ]
                        },
                        tooltip: {
                            valueSuffix: ''
                        }
                    }]

                }));
                var ch1 = new Highcharts.Chart(Highcharts.merge(gaugeOptions, {
                    chart: {
                        renderTo: 'container-rpm'
                    },
                    yAxis: {
                        min: 0,
                        max: 10000,
                        title: {
                            text: 'السيولة الداخلة'
                        }
                    },
                    series: [{
                        name: 'الكمية',
                        data: [CashFlowInValue / 100],
                        borderWidth: 1,
                        shadow: false,
                        useHTML: true,
                        padding: 0,
                        backgroundColor: {
                            linearGradient: {
                                x1: 0,
                                y1: 0,
                                x2: 0,
                                y2: 1
                            },
                            stops: [
                                [0, '#DDD'],
                                [1, '#333']
                            ]
                        },
                        tooltip: {
                            valueSuffix: ''
                        }
                    }]

                }));
            }


        }).error(function (xhr, status, error) {
            window.location.href = "/Home/Error";
        })

    }

    $(function () {
        var charts = new Highcharts.Chart({
            chart: {
                type: 'gauge',
                alignTicks: false,
                plotBackgroundColor: null,
                plotBackgroundImage: null,
                plotBorderWidth: 0,
                plotShadow: false,
                renderTo: 'container'
            },
            title: {
                text: ''
            },
            pane: {
                startAngle: -150,
                endAngle: 150,
                background: [{
                    backgroundColor: {
                        linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                        stops: [
                            [0, '#FFF'],
                            [1, '#333']
                        ]
                    },
                    borderWidth: 0,
                    outerRadius: '109%'
                }, {
                    backgroundColor: {
                        linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1 },
                        stops: [
                            [0, '#333'],
                            [1, '#FFF']
                        ]
                    },
                    borderWidth: 1,
                    outerRadius: '107%'
                }, {
                    // default background
                }, {
                    backgroundColor: '#DDD',
                    borderWidth: 0,
                    outerRadius: '105%',
                    innerRadius: '103%'
                }]
            },
            credits: {

                text: 'Borsa Capital',
                href: 'http://borsacapital.com'
            },
            // the value axis
            yAxis: {
                min: 0,
                max: 200,

                minorTickInterval: 'auto',
                minorTickWidth: 1,
                minorTickLength: 10,
                minorTickPosition: 'inside',
                // minorTickPosition: 'outside',
                minorTickColor: '#666',

                tickPixelInterval: 30,
                tickWidth: 2,
                tickPosition: 'inside',
                //tickPosition: 'outside',
                tickLength: 5,
                tickColor: '#666',
                labels: {
                    distance: 12,
                    step: 2,
                    rotation: 'auto'
                },
                title: {
                    text: ''
                },
                plotBands: [{
                    from: 0,
                    to: 120,
                    color: '#55BF3B' // green
                }, {
                    from: 120,
                    to: 160,
                    color: '#DDDF0D' // yellow
                }, {
                    from: 160,
                    to: 200,
                    color: '#DF5353' // red
                }]
            },

            series: [{
                name: 'M',
                data: [80],
                dataLabels: {
                    borderWidth: 1,
                    shadow: false,
                    useHTML: true,
                    padding: 4,
                    backgroundColor: {
                        linearGradient: {
                            x1: 0,
                            y1: 0,
                            x2: 0,
                            y2: 1
                        },
                        stops: [
                            [0, '#DDD'],
                            [1, '#333']
                        ]
                    }
                },
                tooltip: {
                    valueSuffix: ''
                }
            }]

        },
    // Add some life
    function (chart) {
        if (!chart.renderer.forExport) {
            setInterval(function () {
                var point = chart.series[0].points[0],
                    newVal,
                    inc = Math.round((Math.random() - 0.5) * 20);

                newVal = point.y + inc;
                if (newVal < 0 || newVal > 200) {
                    newVal = point.y - inc;
                }
                point.update(newVal);
            }, 3000);
        }
    });
    });
}]);

App.controller('BcIndicatorsController',["$scope","Page", function ($scope,Page) {
    Page.setTitle('مؤشرات بورصة كابيتال');
    // Display selected tab
    $scope.gotoAnchor = function (id) {
        for (i = 1; i <= 4; i++) {
            $("#" + i + "").removeClass("active");
            $("#tab" + i + "").removeClass("active");
        }
        $("#" + id + "").addClass("active");
        $("#tab" + id + "").addClass("active");
    };
}]);

App.controller('PetrochemicalsController', ["$scope", "$http", "Page", function ($scope, $http, Page) {
    Page.setTitle('صفحة البتروكيماويات');
    // Get GetAllPetrochemicals request
    $http.get("/UTMS/Petrochemicals/GetAllPetrochemicals").success(function (data) {
        if (data == "Error") {
            window.location.href = "/Home/Error";
        }
        else {
            $scope.MyData = data;
        }
    }).error(function (error) {
        window.location.href = "/Home/Error";
    });
}]);

App.controller('KnowledgeController', ["$scope", "$http","Page", function ($scope, $http,Page) {
    Page.setTitle('وسع ثقافتك');
    $scope.knowledges = null;
    // Get All Knowledge
    $http.get("/UTMS/Knowledge/GetAllKnowledge").success(function (data) {
        if (data == "Error") {
            window.location.href = "/Home/Error";
        }
        else {
            $scope.knowledges = data;
        }
    }).error(function (error) {
        alert(error);
    });

    // Dispaly only selected tab
    $scope.gotoAnchor = function (index) {
        for (i = 0; i <= $scope.knowledges.length; i++) {
            $("#" + i + "").removeClass("active");
            $("#tab" + i + "").removeClass("active");
        }
        $("#" + index + "").addClass("active");
        $("#tab" + index + "").addClass("active");
    };

}]);

App.controller('CompaniesMapController',["$scope","Page", function ($scope,Page) {
    Page.setTitle('خارطة الشركات');
    $scope.map = { center: { latitude: 24.3269853, longitude: 45.0858763 }, zoom: 6 };

    $scope.markers = [
        { 'latitude': 24.4564278, 'longitude': 39.6433692, 'message': 'dd' },
        { 'latitude': 24.797819, 'longitude': 46.722355, 'message': 'ee' }
    ];
}]);

