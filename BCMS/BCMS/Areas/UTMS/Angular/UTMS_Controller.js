/// <reference path="../app_UTMS.js" />

App.controller('BorsaCloudController', ["$scope", "$http", function ($scope, $http) {

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
        $.ajax({
            url: '/BorsaCloud/GetMessages',
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function (result) {
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
        }).error(function () {
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

App.controller('MarketCasterController', function ($scope) {
    $scope.loading = true;
    DoLoading();

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
        $.ajax({
            url: '/MarketCaster/GetMessages',
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).success(function (result) {
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
        }).error(function () {
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
});

App.controller('StockUpController', function ($scope) {
    $scope.gotoAnchor = function (id) {
        for (i = 0; i <= 6; i++) {
            $("#" + i + "").removeClass("active");
            $("#li" + i + "").removeClass("active");
        }
        if (id >= 0 && id <= 6) {
            $("#" + id + "").addClass("active");
            $("#li" + id + "").addClass("active");
        }
    };
    $scope.gotoAnchorShare = function (id) {
        for (i = 7; i <= 9; i++) {
            $("#" + i + "").removeClass("active");
            $("#li" + i + "").removeClass("active");
        }
        $("#" + id + "").addClass("active");
        $("#li" + id + "").addClass("active");
    }
});

App.controller('BorsaGraphicsController', ["$scope", "$http", function ($scope, $http) {
    $scope.loading = true;
    DoLoading();
    $http.get("/UTMS/BorsaGraphics/GetAllChartCategories")
        .success(function (data) {
            $scope.ChartCategory = data;
            $scope.loading = false;
        }).error(function () {
            alert("error");
            $scope.loading = false;
        });
}]);

App.controller('AnalysesController', function ($scope, $http, $routeParams) {
    $scope.loading = true;
    DoLoading();
    $scope.CatID = $routeParams.CategoryId;
    $http({
        url: "/UTMS/BorsaGraphics/GetAllChartAnalysesKind",
        method: 'GET',
        params: { id: $scope.CatID }
    }).success(function (data) {
        $scope.ChartAnalysesKind = data;
        $scope.loading = false;
    }).error(function () {
        alert("error");
        $scope.loading = false;
    });
});

App.controller('AnalysesDetailsController', function ($scope, $http, $routeParams) {
    $scope.loading = true;
    DoLoading();
    $scope.KindID = $routeParams.KindId;
    $http({
        url: "/UTMS/BorsaGraphics/GetAllCharts",
        method: 'GET',
        params: { id: $scope.KindID }
    }).success(function (data) {
        $scope.Charts = data;
        $scope.loading = false;
    }).error(function () {
        alert("error");
        $scope.loading = false;
    });

    var modal = document.getElementById('myModal');
    var span = document.getElementsByClassName("close")[0];
    span.onclick = function () {
        modal.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

    $scope.popup = function (id, title) {
        modal.style.display = "block";
        $("#title").html(title);
        $("#content").html("<iframe src='/UTMS/BorsaGraphics/ChartDiv/" + id + "' style='height:400px; width:100%; overflow-y:auto;'></iframe>")
               //.src = "/UTMS/BorsaGraphics/ChartDiv?id=" + id;

        //$http({
        //    url: "/UTMS/BorsaGraphics/ChartDiv",
        //    method: 'GET',
        //    params: { id: id }
        //}).success(function (data) {
        //    $("#content").src
        //}).error(function () {
        //    alert("error");
        //});

    }

});