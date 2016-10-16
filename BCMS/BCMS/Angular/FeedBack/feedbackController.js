﻿/// <reference path="../anonymousApp.js" />


MyApp.controller('FeedbackController', ["$scope", "$http", function ($scope, $http) {

    $scope.message = "";
    $scope.isFormValid = false;
    $scope.validationMessage = "";
    $scope.sent = false;
    $scope.feedback = "";
    $scope.submitText = "إرسال";

    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';

    $scope.feedBackTitle = 'FEEDBACK_TITLE';
    $scope.fillForm = 'FILL_FORM';
    $scope.name = 'name';
    $scope.nameValidation = 'nameValidation';
    $scope.email = 'email';
    $scope.emailValidation = 'EMAIL_VALIDATION';
    $scope.emailIncorrect = 'EMAIL_INCORRECT';
    $scope.suggest = 'SUGGEST';
    $scope.messageValidation = 'messageValidation';
    $scope.capitha = 'capitha';
    $scope.sendBtn = 'SEND_BTN';

    $scope.$watch('SendFeedBack.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });

    var lang=localStorage.getItem('language');
    $scope.Save = function () {
        if (lang == 'en') {
            if ($scope.isFormValid) {
                $("#valid").attr("hidden", "hidden").removeClass("error");
                $scope.validationMessage = "";
                if ($("#txtVerify").val().trim() == "") {
                    $scope.validationMessage = "";

                    $scope.message = "Please enter this number";
                    $("#match").removeAttr("hidden").addClass("error");
                } else {
                    if ($("#txtVerify").val() == $("#capture").text()) {
                        $("#match").attr("hidden", "hidden").removeClass("error");
                        $http.post("/Feedback/Send", this.newFeedback)
                        .success(function (data) {
                            if (data.msg == true) {
                                $scope.sent = true;
                                $scope.feedback = "Message sent succesfuly";
                            } else {
                                alertify.error("Error occured at sending message", 5);
                            }
                        }).error(function (data) {
                            alertify.error("Error occured at sending message", 5);
                        });
                    } else {
                        $scope.message = "The numbers didn't matched please enter the correct numbers";
                        $("#match").removeAttr("hidden").addClass("error");
                    }
                }
            } else {
                $("#valid").removeAttr("hidden").addClass("error");
                $scope.validationMessage = "Please fill out all the blanks";
            }
        }

        else {
            if ($scope.isFormValid) {
                $("#valid").attr("hidden", "hidden").removeClass("error");
                $scope.validationMessage = "";
                if ($("#txtVerify").val().trim() == "") {
                    $scope.validationMessage = "";

                    $scope.message = "من فضلك ادخل الارقام التى امامك"
                    $("#match").removeAttr("hidden").addClass("error");
                } else {
                    if ($("#txtVerify").val() == $("#capture").text()) {
                        $("#match").attr("hidden", "hidden").removeClass("error");
                        $http.post("/Feedback/Send", this.newFeedback)
                        .success(function (data) {
                            if (data.msg == true) {
                                $scope.sent = true;
                                $scope.feedback = "تم ارسال الرساله بنجاح";
                            } else {
                                alertify.error("حدث خطأ فى إرسال الرسالة", 5);
                            }
                        }).error(function (data) {
                            alertify.error("حدث خطأ فى إرسال الرسالة", 5);
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

}]);
