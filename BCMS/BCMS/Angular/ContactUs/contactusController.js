﻿/// <reference path="../anonymousApp.js" />

MyApp.controller('ContactUsController', ["$scope", "$http", function ($scope, $http) {
    DoLoading();
    $scope.loading = true;
    $scope.message = "";
    $scope.isFormValid = false;
    $scope.validationMessage = "";
    $scope.sent = false;
    $scope.feedback = "";

    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';


    $scope.contacUs = 'CONTACT_US';
    $scope.name = 'name';
    $scope.nameValidation = 'nameValidation';
    $scope.email = 'email';
    $scope.emailValidation = 'EMAIL_VALIDATION';
    $scope.emailIncorrect='EMAIL_INCORRECT'
    $scope.topic = 'TOPIC';
    $scope.topicValidation = 'TOPIC_VALIDATION';
    $scope.fbMessage = 'message';
    $scope.messageValidation = 'messageValidation';
    $scope.capitha = 'capitha';
    $scope.sendbtn = 'SEND_BTN'
    var lang = localStorage.getItem('language');

    $scope.newContactUs = {
        name: '',
        email: '',
        subject: '',
        message: ''
    };
    //$scope.Check = function (CheckAvailability) {
    //    return (CheckAvailability) ? "TextBoxWrong" : "TextBoxDone";
    //};
    //$scope.CheckButton = function (CheckAvailability) {
    //    return (CheckAvailability) ? "ButtonForbidden" : "";
    //};

    $scope.$watch('SendMessage.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });

    $scope.Save = function () {
        
        if (lang == 'en') {
            if ($scope.isFormValid) {
                $("#valid").attr("hidden", "hidden").removeClass("error");
                $scope.validationMessage = "";
                if ($("#txtVerify").val().trim() == "") {
                    $scope.message = "Please enter this numbers"
                    $("#match").removeAttr("hidden").addClass("error");
                } else {
                    if ($("#txtVerify").val() == $("#capture").text()) {
                        $("#match").attr("hidden", "hidden").removeClass("error");
                        $scope.loading = true;
                        alertify.set('notifier', 'position', 'bottom-left');
                        $http.post("/ContactUs/Send", this.newContactUs)
                        .success(function (data) {
                            $scope.sent = true;
                            $scope.loading = false;
                            //alertify.success(data.msg, 5);
                            $scope.feedback = "Your message sent succesfuly, Thank you.";
                            $scope.newContactUs = [];
                        }).error(function (data) {
                            $scope.loading = false;
                            alertify.error(data.msg, 5);
                        });
                    } else {
                        $scope.message = "The numbers didn't matched please enter the correct numbers";
                        $("#match").removeAttr("hidden").addClass("error");
                    }
                }
            }
            
        }

        else {
            if ($scope.isFormValid) {
                $("#valid").attr("hidden", "hidden").removeClass("error");
                $scope.validationMessage = "";
                if ($("#txtVerify").val().trim() == "") {
                    $scope.message = "من فضلك ادخل الارقام التى امامك"
                    $("#match").removeAttr("hidden").addClass("error");
                } else {
                    if ($("#txtVerify").val() == $("#capture").text()) {
                        $("#match").attr("hidden", "hidden").removeClass("error");
                        $scope.loading = true;
                        alertify.set('notifier', 'position', 'bottom-left');
                        $http.post("/ContactUs/Send", this.newContactUs)
                        .success(function (data) {
                            $scope.sent = true;
                            $scope.loading = false;
                            //alertify.success(data.msg, 5);
                            $scope.feedback = "تم ارسال الرساله بنجاح";
                            $scope.newContactUs = [];
                        }).error(function (data) {
                            $scope.loading = false;
                            alertify.error(data.msg, 5);
                        });
                    } else {
                        $scope.message = "الارقام غير متطابقه من فضلك اعد كتابة الارقام";
                        $("#match").removeAttr("hidden").addClass("error");
                    }
                }
            } else {
                $("#valid").removeAttr("hidden").addClass("error");
                $scope.validationMessage = "يجب  ملئ جميع الخانات الفارغه";
            }
            
        }

    }
    $scope.loading = false;

}]);