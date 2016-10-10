
//check to push  old data to (CategoriesOld) just first time run page Borsa Cloud
var check = false;
// categories before change
var CategoriesOld = [];
// categories After change
var CategoriesNew = [];
//The oldest values in Categories
var CategoriesOldest = [];

// Onload
$(function () {
    var notifications = $.connection.MessagesHub;
    $.connection.hub.start();
    // when data changing update automaticly
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

        //////////
        //$('#SectorAndCategory').bind('contentchanged', function () {

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
                // First case
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
                    // Second case
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
                    // Third case
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
        //});
        //$('#SectorAndCategory').trigger('contentchanged');
        /////////
    })
    .error(function () {

        alert("Error!");

    });
}



