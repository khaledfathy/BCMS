﻿/// <reference path="../anonymousApp.js" />


MyApp.controller('LoginController', ["$scope", "$http", "$location", function ($scope, $http) {
    //alert("login Controller");
    $scope.IsLogedin = false;
    $scope.login = 'LOGIN';
    $scope.bc = 'bc';
    $scope.email = 'email';
    $scope.password = 'password';
    $scope.rememberMe = 'REMEMBER_ME';
    $scope.forgotPassword = 'FORGET_PASSWORD';
    $scope.createAccount = 'CREATE_ACCOUNT';
    $scope.moreInformation = 'MORE_INFORMATION';
    $scope.loginBtn = 'LOGIN_BUTTON';
    var sendCodeMessage = '';
    $scope.message = '';
    $scope.loading = false;
    DoLoading();
    var userId = getCookie("UserId");
    $scope.LoginUTMS = function () {
        var returUrl = $("#returnUrl").val();
        $scope.loading = true;
        var params = { 'model': this.Member, 'returnUrl': returUrl }
        var lang = getCookie('language');
        switch (lang) {
            case "en":
                $http.post("/Account/Login", params)
                .success(function (data) {
                    $scope.loading = false;
                    if (data != "Admin" && data != "Active" && data != "NotConfirmed" && data != "PasswordError" && data != "Waiting" && data != "ErrorInUserNameOrPassword") {
                        $scope.IsLogedin = true;
                        $scope.message = 'Just a second please...';
                        window.location.href = data;
                    }else {
                        switch (data) {
                            case "Admin":
                                $scope.IsLogedin = true;
                                $scope.message = 'Just a second please...';
                                window.location.href = '/Admin/Home/Index';
                                break;
                            case "Active":
                                $scope.IsLogedin = true;
                                $scope.message = 'Just a second please...'
                                window.location.href = '/UTMS/Home';
                                break;
                            case "Waiting":
                                $scope.IsLogedin = true;
                                sendCodeMessage = "<h2>Your account waiting for approval</h2>";
                                $("#sendCodeMsg").append(sendCodeMessage);
                                break;
                            case "NotConfirmed":
                                $scope.IsLogedin = true;
                                sendCodeMessage = "<h2 id='sendEmail' style='display:none;'>We have sent an email with a confirmation link to your email address. In order to complete the registration process, please click the confirmation link</h2><div id='loginMessage'><h2>Your account has not been activated yet, please check your email address and click the confirmation link</h2>";
                                sendCodeMessage += "<h2> If you do not receive a confirmation email, please click <a href=\"javascript:sendCode('" + userId + "')\">here </a>to send another one</h2></div>";
                                $("#sendCodeMsg").append(sendCodeMessage);
                                break;
                            case "PasswordError":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Password is not correct", 5);
                                break;
                            case "ErrorInUserNameOrPassword":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Email or Password is incorrect", 5);
                                break;
                            default:
                                $scope.loading = false;
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Email or Password is incorrect", 5);
                        }
                    }
                    
                }).error(function (data) {
                    $scope.loading = false;
                    alertify.set('notifier', 'position', 'bottom-right');
                    alertify.error("Error in login process");
                });
                break;
            default:
                $http.post("/Account/Login", params)
                .success(function (data) {
                    $scope.loading = false;
                    if (data != "Admin" && data != "Active" && data != "NotConfirmed" && data != "PasswordError" && data != "Waiting" && data != "ErrorInUserNameOrPassword") {
                        $scope.IsLogedin = true;
                        $scope.message = 'لحظة من فضلك...';
                        window.location.href = data;

                    } else {
                        switch (data) {
                            case "Admin":
                                $scope.IsLogedin = true;
                                $scope.message = 'لحظة من فضلك...'
                                window.location.href = '/Admin/Home/Index';
                                break;
                            case "Active":
                                $scope.IsLogedin = true;
                                $scope.message = 'لحظة من فضلك...'
                                window.location.href = '/UTMS/Home';
                                break;
                            case "Waiting":
                                sendCodeMessage = "<h2>أنت قيد الانتظار لحين الموافقه على حسابك من قبل مدير الموقع</h2>";
                                $scope.IsLogedin = true;
                                $("#sendCodeMsg").append(sendCodeMessage);
                                break;
                            case "NotConfirmed":
                                $scope.IsLogedin = true;
                                $scope.sendCodeMessage = '';
                                sendCodeMessage = "<h2 id='sendEmail' style='display:none;'>لقد تم إرسال رسالة بريد إلكترونى على حسابك، برجاء تفقد البريد الإلكترونى الخاص بك</h2><div id='loginMessage'><h2>انت لم تقم بتاكيد حسابك، برجاء تأكيد الحساب أولا، من فضلك قم بفحص البريد الإلكترونى الخاص بك</h2>";
                                sendCodeMessage += "<h2> لإعادة ارسال بريد الكترونى آخر برجاء الضغط <a href=\"javascript:sendCode('" + userId + "')\">هنــا</a></h2></div>";
                                $("#sendCodeMsg").append(sendCodeMessage);
                                break;
                            case "PasswordError":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-left');
                                alertify.error("كلمة المرور غير صحيحة", 5);
                                break;
                            case "ErrorInUserNameOrPassword":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-left');
                                alertify.error("البريد الإلكترونى أو كلمة المرور غير صحيحة", 5);
                                break;
                            default:
                                $scope.loading = false;
                                alertify.set('notifier', 'position', 'bottom-left');
                                alertify.error("البريد الإلكترونى أو كلمة المرور غير صحيحة", 5);
                        }
                    }
                    
                }).error(function (data) {
                    $scope.loading = false;
                    alertify.set('notifier', 'position', 'bottom-left');
                    alertify.error("خطأ فى عملية الدخول");
                });
        }
    };
}]);

MyApp.controller('RegisterController', function ($scope, registerationService) {
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';

    $scope.newUser = 'newUser';
    $scope.fullName = 'fullName';
    $scope.fName = 'fName';
    $scope.fNameValidation = 'fNameValidation';
    $scope.mName = 'mName';
    $scope.lName = 'lName';
    $scope.lNameValidation = 'lNameValidation';
    $scope.userName = 'USER_NAME';
    $scope.userNameValidation = 'USER_NAME_VALIDATION';
    $scope.email = 'email';
    $scope.emailValidation = 'EMAIL_VALIDATION';
    $scope.password = 'password';
    $scope.passwordValidation = 'passwordValidation';
    $scope.cPassword = 'cPassword';
    $scope.cPasswordValidation = 'cPasswordValidation';
    $scope.registerBtn = 'REGISTER_BUTTON';
    var lang = localStorage.getItem('language');
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.validationSummary = false;
    $scope.registerSuccess = '';
    //Check Form Validation
    $scope.$watch('f1.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    //Save Data
    $scope.SaveData = function (user) {
        
        var lang = getCookie('language');
        if (lang == 'en') {
            if ($scope.isFormValid) {
                registerationService.saveFormData(user, lang).then(function (d) {
                    if (d == "Success") {
                        $scope.registerSuccess = "We have sent an email with a confirmation link to your email address. In order to complete the registration process, please click the confirmation link";
                        $scope.submitted = true;
                    } else if (d == 'EmailAlreadyToken') {
                        $scope.validationSummary = true;
                        $scope.message = 'This email has already used before, please use another one.'
                    } else if (d == 'InvalidPassword') {
                        $scope.validationSummary = true;
                        $scope.message = "Password must be 8 characters at least includes numbers and one capital letter at least and special characters like (!, @, #, $, %, ^, &, ... etc)";
                    }
                    else {
                        alert('Error');
                    }
                });
            } else {
                $scope.validationSummary = true;
                $scope.message = "Please fill all blanks.";
            }
        } else {
            if ($scope.isFormValid) {
                registerationService.saveFormData(user, lang).then(function (d) {
                    if (d == "Success") {
                        $scope.registerSuccess = "لقد قمت بعمل حساب على بورصه كابيتال لتفعيل الحساب برجاء تأكيد الحساب من البريد الالكترونى الخاص بك";
                        $scope.submitted = true;
                    } else if (d == 'EmailAlreadyToken') {
                        $scope.validationSummary = true;
                        $scope.message = 'البريد الالكترونى مستخدم من قبل من فضلك استخدم بريد الكترونى اخر'
                    } else if (d == 'InvalidPassword') {
                        $scope.validationSummary = true;
                        $scope.message = "كلمة المرور لا تقل عن ثمانية احرف كبيره وصغيره من بينهم رقم واحد على الاقل ورموز مثل(@،#،$،%،!،_،-،=،+ ...)";
                    } else {
                        alert('هناك خطأ ما');
                    }
                });
            } else {
                $scope.validationSummary = true;
                $scope.message = "من فضلك اكمل البيانات الناقصة";
            }
        }
    }
});

MyApp.controller('ForgotpasswordController', ["$scope", "$http", function ($scope, $http) {

    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.forgotPassword = 'FORGOT_PASSWORD';
    $scope.plzEnterEmail = 'PLZ_ENTER_EMAIL';
    $scope.email = 'email';
    $scope.emailIncorrect = 'EMAIL_INCORRECT';
    $scope.sendBtn = 'SEND_BTN';

    $scope.emailSent = false;
    $scope.loading = false;
    $scope.message = "";
    DoLoading();

    $scope.Send = function () {
        var lang = getCookie('language');

        $scope.loading = true;
        if (lang == 'en') {
            $http.post("/Account/ForgotPassword", this.Member)
            .success(function (data) {
                $scope.loading = false;
                $scope.emailSent = true;
                switch (data) {
                    case "InvalidUser":
                        $scope.message = "Invalid email address";
                    case "NotConfirmed":
                        $scope.message = "Your account is not confirmed yet";
                    case "EmailSent":
                        $scope.message = "Please check your email address and click the link in email";
                }
            }).error(function (data) {
                $scope.loading = false;
                alertify.set('notifier', 'position', 'bottom-left');
                alertify.error("Processing Error!, please try again. ", 5);
            });
        }

        else {
            $http.post("/Account/ForgotPassword", this.Member)
            .success(function (data) {
                $scope.loading = false;
                $scope.emailSent = true;
                switch (data) {
                    case "InvalidUser":
                        $scope.message = "البريد الالكترونى غير متاح";
                    case "NotConfirmed":
                        $scope.message = "حسابك لم يتم تأكيده بعد، من فضلك قم بتأكيد حسابك عن طريق الضغط على الرابط الذى تم ارساله الى بريدك الالكترونى";
                    case "EmailSent":
                        $scope.message = "من فضلك افحص بريد الالكترونى وقم بالضغط على الرابط";
                }
            }).error(function (data) {
                $scope.loading = false;
                alertify.set('notifier', 'position', 'bottom-left');
                alertify.error(data + "خطأ فى عملية الإرسال، من فضلك اعد المحاولة ", 5);
            });
        }
    }
}]);

MyApp.controller('ResetpasswordController', ["$scope", "$http", function ($scope, $http) {
    $scope.loading = false;
    $scope.submitted = false;
    $scope.message = '';
    var message = '';
    DoLoading();
    $scope.Send = function () {
        $scope.loading = true;
        this.user.Code = $("#code").val();
        // $scope.user.code = $("#code").val();
        $http.post("/Account/ResetPassword", this.user)
     .success(function (data) {
         $scope.loading = false;

         switch (data) {
             case 'InvalidUser':
                 message = 'Invalid email address please re-enter your email';
             case 'Success':
                 message = 'Password changed succefully please click <a href="http://localhost:2302/#/Login">here</a> to login';
                 $("#feedback").append(message);
                 $scope.submitted = true;
         }


         //alertify.set('notifier', 'position', 'bottom-left');
         //if (data.indexOf("خ") > -1) {
         //    alertify.error(data, 5);
         //} else {
         //    alertify.success(data, 5);
         //    $scope.Member = [];
         //}
     }).error(function (data) {
         $scope.loading = false;
         alertify.set('notifier', 'position', 'bottom-left');
         alertify.error(data + " خطأ فى عملية إعدة التعيين ", 5);
     });
    }
}]);

var compareTo = function () {
    return {
        require: "ngModel",
        scope: {
            otherModelValue: "=compareTo"
        },
        link: function (scope, element, attributes, ngModel) {
            ngModel.$validators.compareTo = function (modelValue) {
                return modelValue == scope.otherModelValue;
            };
            scope.$watch("otherModelValue", function () {
                ngModel.$validate();
            });
        }
    };
};

MyApp.directive("compareTo", compareTo);


function sendCode(userId) {
    var lang = localStorage.getItem('language');
    $.ajax({
        type: 'POST',
        url: '/Account/SendCode',
        data: { "userId": userId, "language": lang },
        success: function (response) {
            //alert("success");
            $("#loginMessage").css('display', 'none');
            $("#sendEmail").css('display', 'block');
        },
        beforeSend: function () {

        },
        complete: function () {

        },
        error: function () {
            alert("error");
        }
    });
}
