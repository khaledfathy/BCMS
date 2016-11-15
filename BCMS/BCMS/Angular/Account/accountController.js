/// <reference path="../anonymousApp.js" />
/// <reference path="C:\Users\sameh\Desktop\BCMS\BCMS\BCMS\Scripts/angular.js" />

// Login Controller
MyApp.controller('LoginController', ["$scope", "$http", "$location", "$compile", "Page", function ($scope, $http, $location, $compile, Page) {
    // Set page title
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Login | Borsa Capital')
    } else {
        Page.setTitle('تسجيل الدخول | بورصة كابيتال')
    }
    // Translations
    $scope.login = 'LOGIN';
    $scope.bc = 'bc';
    $scope.email = 'email';
    $scope.userName = 'USER_NAME';
    $scope.userNameOrEmail = 'USERNAME_EMAIL';
    $scope.password = 'password';
    $scope.rememberMe = 'REMEMBER_ME';
    $scope.forgotPassword = 'FORGET_PASSWORD';
    $scope.createAccount = 'REGISTER_BUTTON';
    $scope.moreInformation = 'MORE_INFORMATION';
    $scope.loginBtn = 'LOGIN_BUTTON';
    $scope.dontHaveAccount = "DONT_HAVE_ACCOUNT";
    // Some variable that will be used later
    $scope.IsLogedin = false;
    var sendCodeMessage = '';
    $scope.message = '';
    var userId = getCookie("UserId");
    var params = null;
    $scope.isFormValid = false;
    //Check Form Validation
    $scope.$watch('LoginForm.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    // Check if user logged if from another device or not
    $scope.LoginChecker = function () {
        var lang = getCookie('language');
        var returnUrl = $("#returnUrl").val();
        var member = this.Member;
        params = { 'model': this.Member, 'returnUrl': returnUrl };
        switch (lang) {
            case "en":
                if ($scope.isFormValid) {
                    $http.post("/Account/LoginChecker", params).success(function (data) {
                        switch (data) {
                            case "Connected":
                                var popup = '<div id="myModal" class="modal"><div class="modal-content" style="width:600px;"><div class="modal-header"><span class="close" ng-click="close()">×</span><h2 id="title" style="text-align:center;">Warning</h2></div>';
                                popup += '<div class="modal-body" style="text-align:center;"><p>You are already logged in from another device</p><p>Do you want to log off from there and log in from here?</p>';
                                popup += '<hr /><a ng-click="Login()" class="button alert">Yes</a>&nbsp;<a class="button" ng-click="close()" style="width:39px;">No</a></div></div></div>';
                                angular.element("#login").append($compile(popup)($scope));
                                angular.element("#myModal").css("display", "block");
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
                            case "ErrorInUserNameOrPassword":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Email or Password is incorrect", 5);
                                break;
                            case "Error":
                                window.location.href = "/Home/Error";
                            default:
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Email or Password is incorrect", 5);
                        }
                    }).error(function (data) {
                        window.location.href = "/Home/Error";
                    });
                } else {
                    alertify.set('notifier', 'position', 'bottom-right');
                    alertify.error("Please enter Username or Email and Password", 10);
                }

                break;
            default:
                if ($scope.isFormValid) {
                    $http.post("/Account/LoginChecker", params).success(function (data) {
                        switch (data) {
                            case "Connected":
                                var popup = '<div id="myModal" class="modal"><div class="modal-content" style="width:600px;"><div class="modal-header"><span class="close" ng-click="close()">×</span><h2 id="title" style="text-align:center;">تحذير</h2></div>';
                                popup += '<div class="modal-body" style="text-align:center;"><p>أنت بالفعل مسجل دخولك من جهاز اخر</p><p>هل تريد تسجيل الخروج من الجهاز الاخر وتسجيل الدخول من هنا؟ </p>';
                                popup += '<hr /><a ng-click="Login()" class="button alert">نعم</a>&nbsp;<a class="button" ng-click="close()" style="width:39px;">لا</a></div></div></div>';
                                angular.element("#login").append($compile(popup)($scope));
                                angular.element("#myModal").css("display", "block");
                                break;
                            case "Active":
                                $scope.Login();
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
                            case "ErrorInUserNameOrPassword":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-left');
                                alertify.error("البريد الإلكترونى أو كلمة المرور غير صحيحة", 5);
                                break;
                            case "Error":
                                window.location.href = "/Home/Error";
                            default:
                                alertify.set('notifier', 'position', 'bottom-left');
                                alertify.error("البريد الإلكترونى أو كلمة المرور غير صحيحة", 5);
                        }
                    }).error(function (data) {
                        window.location.href = "/Home/Error";
                    });
                } else {
                    alertify.set('notifier', 'position', 'bottom-left');
                    alertify.error("من فضلك ادخل إسم المستخدم أو البريد الالكترونى وكلمة المرور", 10);
                }
        }

    };
    // Login request function
    $scope.Login = function () {
        $scope.close();
        var lang = getCookie('language');
        switch (lang) {
            case "en":
                $http.post("/Account/Login", params).success(function (response) {
                    if (response != "Admin" && response != "Active" && response != "NotConfirmed" && response != "PasswordError" && response != "Waiting" && response != "ErrorInUserNameOrPassword") {
                        $scope.IsLogedin = true;
                        $scope.message = 'Just a second please...';
                        window.location.href = response;
                    } else {
                        switch (response) {
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
                            case "PasswordError":
                                $scope.IsLogedin = false;
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Password is not correct", 5);
                                break;
                            case "Error":
                                window.location.href = "/Home/Error";
                            default:
                                alertify.set('notifier', 'position', 'bottom-right');
                                alertify.error("Email or Password is incorrect", 5);
                        }
                    }
                }).error(function (response) {

                    window.location.href = "/Home/Error";
                })
                break;
            default:
                $http.post("/Account/Login", params)
                  .success(function (response) {
                      if (response != "Admin" && response != "Active" && response != "NotConfirmed" && response != "PasswordError" && response != "Waiting" && response != "ErrorInUserNameOrPassword") {
                          $scope.IsLogedin = true;
                          $scope.message = 'لحظة من فضلك...';
                          window.location.href = response;
                      } else {
                          switch (response) {
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
                              case "PasswordError":
                                  $scope.IsLogedin = false;
                                  alertify.set('notifier', 'position', 'bottom-left');
                                  alertify.error("كلمة المرور غير صحيحة", 5);
                                  break;
                              case "Error":
                                  window.location.href = "/Home/Error";
                              default:
                                  alertify.set('notifier', 'position', 'bottom-left');
                                  alertify.error("البريد الإلكترونى أو كلمة المرور غير صحيحة", 5);
                          }
                      }
                  }).error(function (response) {

                      window.location.href = "/Home/Error";
                  });
        }
    }
    // Close popup
    $scope.close = function () {
        var modal = document.getElementById('myModal');
        if (modal != null)
            modal.style.display = "none";
    }
}]);
// Register controller
MyApp.controller('RegisterController', function ($scope, registerationService, Page) {
    // Set page title
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Register | Borsa Capital')
    } else {
        Page.setTitle('تسجيل | بورصة كابيتال')
    }
    // Translation
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
    $scope.invalidUserName = "INVALID_USERNAME";
    $scope.email = 'email';
    $scope.emailValidation = 'EMAIL_VALIDATION';
    $scope.emailIncorrect = 'EMAIL_INCORRECT';
    $scope.password = 'password';
    $scope.passwordValidation = 'passwordValidation';
    $scope.incorrectPassword = 'INCORRECT_PASSWORD';
    $scope.cPassword = 'cPassword';
    $scope.cPasswordValidation = 'cPasswordValidation';
    $scope.registerBtn = 'REGISTER_BUTTON';
    // Regular expressions for Email, Username and Password
    $scope.emailformat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,4}$/;
    $scope.userNamePatern = /^(?=.{8,30}$)(?![_.0-9])(?!.*[_.]{2})[a-zA-Z0-9._]+(?![_.])$/;
    $scope.passwordformat = /((?=.*\d)(?=.*[a-z])+(?=.*[A-Z])(?=.*[@#$%!%=+]).{8,20})/;
    // Some variable used later
    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.validationSummary = false;
    $scope.registerSuccess = '';

    //Check Form Validation
    $scope.$watch('RegisterForm.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    // Register request function
    $scope.SaveData = function (user) {
        var lang = getCookie('language');
        if (lang == 'en') {
            if ($scope.isFormValid) {
                registerationService.saveFormData(user, lang).then(function (response) {
                    switch (response) {
                        case "Success":
                            $scope.registerSuccess = "We have sent an email with a confirmation link to your email address. In order to complete the registration process, please click the confirmation link";
                            $scope.submitted = true;
                            break;
                        case 'EmailAlreadyToken':
                            $scope.validationSummary = true;
                            $scope.message = 'This email is already used before, please enter another one.';
                            break;
                        case "UserNameAlreadyToken":
                            $scope.validationSummary = true;
                            $scope.message = 'Username is already token before, please enter another one.';
                            break;
                        case 'InvalidPassword':
                            $scope.validationSummary = true;
                            $scope.message = "Password must be 8 characters at least includes numbers and one capital letter at least and special characters like (!, @, #, $, %, ^, &, ... etc)";
                            break;
                        case "Error":
                            $scope.validationSummary = true;
                            $scope.message = 'Error!';
                            break;
                        default:
                            alertify.set('notifier', 'position', 'bottom-right');
                            alertify.error("Error occured please try again", 5);
                    }
                });
            } else {
                $scope.validationSummary = true;
                $scope.message = "Please fill all blanks.";
            }
        } else {
            if ($scope.isFormValid) {
                registerationService.saveFormData(user, lang).then(function (response) {
                    switch (response) {
                        case "Success":
                            $scope.registerSuccess = "لقد قمت بعمل حساب على بورصه كابيتال لتفعيل الحساب برجاء تأكيد الحساب من البريد الالكترونى الخاص بك";
                            $scope.submitted = true;
                            break;
                        case 'EmailAlreadyToken':
                            $scope.validationSummary = true;
                            $scope.message = 'البريد الالكترونى مستخدم من قبل من فضلك استخدم بريد الكترونى اخر'
                            break;
                        case "UserNameAlreadyToken":
                            $scope.validationSummary = true;
                            $scope.message = 'إسم المستخدم موجود بالفعل من فضلك ادخل إسم مستخدم آخر';
                            break;
                        case 'InvalidPassword':
                            $scope.validationSummary = true;
                            $scope.message = "كلمة المرور لا تقل عن ثمانية احرف كبيره وصغيره من بينهم رقم واحد على الاقل ورموز مثل(@،#،$،%،!،_،-،=،+ ...)";
                            break;
                        case "Error":
                            $scope.validationSummary = true;
                            $scope.message = 'خطأ!';
                            break;
                        default:
                            alertify.set('notifier', 'position', 'bottom-left');
                            alertify.error("حدث خطأ ما! من فضلك حاول مرة اخرى", 5);
                    }
                });
            } else {
                $scope.validationSummary = true;
                $scope.message = "من فضلك اكمل البيانات الناقصة";
            }
        }
    }
});
// Forgot password controller
MyApp.controller('ForgotpasswordController', ["$scope", "$http", "$compile", function ($scope, $http, $compile, Page) {
    // Set page title
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Forgot password')
    } else {
        Page.setTitle('نسيت كلمة المرور')
    }
    // Translation
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.forgotPassword = 'FORGOT_PASSWORD';
    $scope.plzEnterEmail = 'PLZ_ENTER_EMAIL';
    $scope.email = 'email';
    $scope.emailValidation = 'EMAIL_VALIDATION';
    $scope.emailIncorrect = 'EMAIL_INCORRECT';
    $scope.sendBtn = 'SEND_BTN';
    // Regular expression for Email
    $scope.emailformat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;
    //Some variables used later
    $scope.clicked = false;
    $scope.emailSent = false;
    $scope.message = "";
    $scope.isFormValid = false;
    $scope.validationSummary = false;
    var UserEmail = null;
    // Check form validation
    $scope.$watch('ForgetPasswordForm.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    // Forgot password request function
    $scope.Send = function (Member) {
        UserEmail = Member;
        var lang = getCookie('language');
        if ($scope.isFormValid) {
            if (lang == 'en') {
                $http.post("/Account/ForgotPassword", UserEmail)
                .success(function (data) {
                    $scope.emailSent = true;
                    switch (data) {
                        case "InvalidUser":
                            $scope.validationSummary = true;
                            $scope.message = "Invalid email address";
                            break;
                        case "NotConfirmed":
                            var message = "Your account is not confirmed yet, please verify your email first";
                            angular.element("#feedbackdiv").html($compile(message)($scope));
                            break;
                        case "SendingFailed":
                            alertify.set('notifier', 'position', 'bottom-left');
                            alertify.error("Processing Error!, please try again. ", 8);
                            break;
                        case "EmailSent":
                            var feedback = "<h2>Please check your email address and click the link in it, to reset your password</h2>";
                            feedback += "<h3>To send another email please click <a ng-click='SendCallBack()'>here</a></h3>"
                            angular.element("#feedbackdiv").html($compile(feedback)($scope));
                            break;
                        case "Error":
                            window.location.href = "/Home/Error";
                    }
                }).error(function (data) {
                    window.location.href = "/Home/Error";
                });
            }

            else {
                $http.post("/Account/ForgotPassword", UserEmail)
                .success(function (data) {

                    switch (data) {
                        case "InvalidUser":
                            $scope.validationSummary = true;
                            $scope.message = "البريد الالكترونى غير متاح";
                            break;
                        case "NotConfirmed":
                            $scope.emailSent = true;
                            var message = "حسابك لم يتم تأكيده بعد، من فضلك قم بتأكيد حسابك عن طريق الضغط على الرابط الذى تم ارساله الى بريدك الالكترونى";
                            angular.element("#feedbackdiv").html($compile(message)($scope));
                            break;
                        case "SendingFailed":
                            alertify.set('notifier', 'position', 'bottom-left');
                            alertify.error("خطأ فى عملية الإرسال، من فضلك اعد المحاولة ", 8);
                            break;
                        case "EmailSent":
                            $scope.emailSent = true;
                            var feedback = "<h2>من فضلك افحص البريد الالكترونى وقم بالضغط على الرابط الموجود به لإعادة تعيين كلمة المرور الجديدة</h2>";
                            feedback += "<h3>لإعادة ارسال بريد الكترونى اخر من فضلك اضغط <a ng-click='SendCallBack()'>هنــا</a></h3>";
                            angular.element("#feedbackdiv").html($compile(feedback)($scope));
                            break;
                        case "Error":
                            window.location.href = "/Home/Error";
                    }
                }).error(function (data) {

                    window.location.href = "/Home/Error";
                });
            }
        }
    }
    // This is for sendin another email link
    $scope.SendCallBack = function () {
        $scope.Send(UserEmail);
    }
}]);
// Reset password controller
MyApp.controller('ResetpasswordController', ["$scope", "$http", "$timeout", "Page", function ($scope, $http, $timeout, Page) {
    // Set page title
    var lang = getCookie('language');
    if (lang == 'en') {
        Page.setTitle('Reset Password');
    } else {
        Page.setTitle('إعادة تعيين كلمة المرور');
    }
    // Translation
    $scope.officialSponsors = 'OFFICIAL_SPONSORS';
    $scope.diamondSponsor = 'DIAMOND_SPONSOR';
    $scope.goldenSponsor = 'GOLDEN_SPONSOR';
    $scope.platinumSponsor = 'PLATINUM_SPONSOR';
    $scope.silverSponsor = 'SILVER_SPONSOR';
    $scope.resetPassword = 'RESET_PASSWORD';
    $scope.newPassword = 'NEW_PASSWORD';
    $scope.confirmNewPassword = 'CONFIRM_NEW_PASSWORD';
    $scope.passwordValidation = 'passwordValidation';
    $scope.email = 'email';
    $scope.emailValidation = 'EMAIL_VALIDATION';
    $scope.incorrectEmail = 'EMAIL_INCORRECT';
    $scope.cPasswordValidation = 'cPasswordValidation';
    $scope.incorrectPassword = 'INCORRECT_PASSWORD';
    $scope.sendbtn = 'SEND_BTN';
    // Some variable that will be used later
    $scope.clicked = false;
    $scope.submitted = false;
    $scope.message = '';
    $scope.passwordMessage = '';
    var message = '';
    $scope.isFormValid = false;
    $scope.validationSummary = false;
    // Regular expressions for Email and Password
    $scope.emailformat = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;
    $scope.passwordformat = /((?=.*\d)(?=.*[a-z])+(?=.*[A-Z])(?=.*[@#$%!%=+]).{8,20})/;
    // Check form validation
    $scope.$watch('ResetPasswordForm.$valid', function (newValue) {
        $scope.isFormValid = newValue;
    });
    // Reset password request function
    $scope.Send = function (user) {
        var lang = getCookie('language');
        user.Code = $("#code").val();
        if (lang == 'en') {
            if ($scope.isFormValid) {
                $http.post("/Account/ResetPassword", user).success(function (data) {
                    switch (data) {
                        case 'InvalidUser':
                            $scope.message = 'Invalid email address please re-enter your email';
                            break;
                        case 'Success':
                            message = 'Password changed succefully please click <a href="http://localhost:2302/#/Login">here</a> to login';
                            $("#feedback").html(message);
                            $scope.submitted = true;
                            break;
                        case 'InvalidEmailOrPassword':
                            $scope.validationSummary = true;
                            $scope.message = "Error in Email or Password";
                            break;
                        case "Error":
                            window.location.href = "/Home/Error";
                        default:
                            alertify.set('notifier', 'position', 'bottom-left');
                            alertify.error("Error! please check internet connection", 5);
                    }
                }).error(function (data) {
                    alertify.set('notifier', 'position', 'bottom-left');
                    alertify.error("Error! please check internet connection", 5);
                });
            } else {
                $scope.validationSummary = true;
                message = "Please complete all fields consistent with conditions";
            }

        } else {
            if ($scope.isFormValid) {
                $http.post("/Account/ResetPassword", this.user).success(function (data) {
                    switch (data) {
                        case 'InvalidUser':
                            $scope.message = 'البريد الالكترونى غير مدون فى سجلاتنا اذا كنت مستخدم جديد برجاء التسجيل اولا';
                            break;
                        case 'Success':
                            message = 'تم إعادة تعيين كلمة المرور بنجاح للدخول للموقع اضغط  <a href="http://localhost:2302/#/Login">هنــــا</a>';
                            $("#feedback").html(message);
                            $scope.submitted = true;
                            break;
                        case 'InvalidEmailOrPassword':
                            $scope.validationSummary = true;
                            $scope.message = "خطأ فى البريد الالكترونى او كلمة المرور";
                            $scope.passwordMessage = "كلمة المرور لا تقل عن ثمانية احرف كبيره وصغيره من بينهم رقم واحد على الاقل ورموز مثل(@،#،$،%،!،_،-،=،+ ...)";
                            break;
                        case "Error":
                            window.location.href = "/Home/Error";
                        default:
                            alertify.set('notifier', 'position', 'bottom-right');
                            alertify.error("خطأ! من فضلك تأكد من أنك متصل بالانترنت", 5);
                    }
                }).error(function (data) {
                    window.location.href = "/Home/Error";
                });
            } else {
                $scope.validationSummary = true;
                $scope.message = "من فضلك املأ الخانات بما يتناسب مع الشروط";

            }
        }
    }
}]);
// User profile controller
MyApp.controller('ProfileController', function ($scope, Page, $http) {
    // Set page title
    var lang = getCookie('language');
    var Name = getCookie('FullName');
    if (lang == 'en') {
        Page.setTitle(Name);
    } else {
        Page.setTitle(Name);
    }
    // Translation
    $scope.fullName = 'fullName';
    $scope.fName = 'fName';
    $scope.fNameValidation = 'fNameValidation';
    $scope.mName = 'mName';
    $scope.lName = 'lName';
    $scope.lNameValidation = 'lNameValidation';
    $scope.userName = 'USER_NAME';
    $scope.changePass = 'CHANGE_PASSWORD';
    $scope.oldPassword = 'OLD_PASSWORD'
    $scope.newPassword = 'NEW_PASSWORD';
    $scope.confirmNewPassword = 'CONFIRM_NEW_PASSWORD';
    $scope.passwordIncorrect = 'INCORRECT_PASSWORD';
    $scope.edit = 'EDIT';
    $scope.save = 'SAVE';
    $scope.cancel = 'CANCEL';
    $scope.oldPasswordValidation = 'OLD_PASSWORD_VALIDATION';
    $scope.newPasswordValidation = 'NEW_PASSWORD_VALIDATION';
    $scope.confirmNewPasswordValidation = 'CONFIRM_NEW_PASSWORD_VALIDATION';
    $scope.passwordChangedMessage = 'PASSWORD_CHANGED';
    $scope.passwordNotMatched = 'PASSWORD_NOT_MATCHED';
    // Regular expression for password
    $scope.passwordformat = /((?=.*\d)(?=.*[a-z])+(?=.*[A-Z])(?=.*[@#$%!%=+]).{8,20})/;
    // Some variables that will be used later
    $scope.PasswordChanged = false;
    $scope.UserData = '';
    $scope.clicked = false;
    $scope.editNameValidSum = false;
    $scope.changePassValidSum = false;
    $scope.EditNameMessage = '';
    $scope.ChangePassMessage = '';
    $scope.isEditNameFormValid = false;
    $scope.isChangePassFormValid = false;
    $scope.model = {
        FirstName: '',
        MiddleName: '',
        LastName: ''
    }
    $scope.passmodel = {
        OldPassword: '',
        NewPassword: '',
        ConfirmPassword: ''
    }
    // Check Edit name form validation
    $scope.$watch('editnameform.$valid', function (newValue) {
        $scope.isEditNameFormValid = newValue;
    })
    // Check Change password form validation
    $scope.$watch('ChangePasswordForm.$valid', function (newValue) {
        $scope.isChangePassFormValid = newValue;
    })
    // Get user data function
    $scope.getUser = function () {
        $http.get('/Manage/UserProfile').success(function (response) {
            $scope.UserData = response;
            $scope.model.FirstName = response.FirstName;
            $scope.model.MiddleName = response.MiddleName;
            $scope.model.LastName = response.LastName;
        }).error(function (response) {
            alert("Error!");
        });
    }
    // Call function getUser 
    $scope.getUser();
    // Update Name of use, post request function
    $scope.UpdateName = function (model) {
        var lang = getCookie('language');
        if (lang == 'en') {
            if ($scope.isEditNameFormValid) {
                $http.post("/Manage/EditName", model).success(function (response) {

                    if (response == "Success") {
                        $scope.getUser();
                        $scope.editname = false;
                    } else {
                        alert("Error!");
                    }
                }).error(function (response) {
                    alert("Error!");
                })
            } else {
                $scope.EditNameMessage = "Please enter you First Name and Last Name at least";
                $scope.editNameValidSum = true;
            }

        } else {
            if ($scope.isEditNameFormValid) {
                $http.post("/Manage/EditName", model).success(function (response) {
                    if (response == "Success") {
                        $scope.getUser();
                        $scope.editname = false;
                    } else {
                        alert("Error!");
                    }
                }).error(function (response) {
                    alert("Error!");
                })
            } else {
                $scope.EditNameMessage = "من فضلك ادخل اسمك الاول واسم العائله على الاقل";
                $scope.editNameValidSum = true;
            }

        }

    }
    // Change password, post request function
    $scope.changePassword = function (changePasswordModel) {
        var lang = getCookie('language');
        if (lang == 'en') {
            if ($scope.isChangePassFormValid) {
                $http.post("/Manage/ChangePassword", changePasswordModel).success(function (response) {
                    switch (response) {
                        case "Success":
                            $scope.changepassword = false;
                            alertify.set('notifier', 'position', 'bottom-right');
                            alertify.success("Password changed succesfully", 5);
                            // Reset form
                            $scope.passmodel = {
                                OldPassword: null,
                                NewPassword: null,
                                ConfirmPassword: null
                            }
                            break;
                        case "NotValid":
                            $scope.ChangePassMessage = "All fields required";
                            $scope.changePassValidSum = true;
                            break;
                        case "Error":
                            $scope.ChangePassMessage = "Error occurred!, please be sure that you enter the current password correctly";
                            $scope.changePassValidSum = true;
                            break;
                        default:
                            $scope.ChangePassMessage = "Error occurred!, please be sure that you enter the current password correctly";
                            $scope.changePassValidSum = true;
                            break;
                    }
                }).error(function (response) {
                    alert("Error!");
                })
            } else {
                $scope.ChangePassMessage = "All fields required";
                $scope.changePassValidSum = true;
            }

        } else {
            if ($scope.isChangePassFormValid) {
                $http.post("/Manage/ChangePassword", changePasswordModel).success(function (response) {
                    switch (response) {
                        case "Success":
                            $scope.changepassword = false;
                            alertify.set('notifier', 'position', 'bottom-left');
                            alertify.success("تم تغيير كلمة المرور بنجاح", 5);
                            //Reset form
                            $scope.passmodel = {
                                OldPassword: null,
                                NewPassword: null,
                                ConfirmPassword: null
                            }
                            break;
                        case "NotValid":
                            $scope.ChangePassMessage = "كل الحقول مطلوبة";
                            $scope.changePassValidSum = true;
                            break;
                        case "Error":
                            $scope.ChangePassMessage = "حدث خطأ من فضلك تأكد انك تدخل كلمة الحالية بشكل صحيح";
                            $scope.changePassValidSum = true;
                            break;
                        default:
                            $scope.ChangePassMessage = "حدث خطأ من فضلك تأكد انك تدخل كلمة الحالية بشكل صحيح";
                            $scope.changePassValidSum = true;
                            break;
                    }

                }).error(function (response) {
                    alert("Error!");
                })
            } else {
                $scope.ChangePassMessage = "كل الحقول مطلوبة";
                $scope.changePassValidSum = true;
            }

        }
    }
})
// Compare to directive for confirm password field
MyApp.directive("compareTo", function () {
    return {
        require: "ngModel",
        scope: {
            otherModelValue: "=compareTo"
        },
        link: function (scope, element, attributes, ngModel) {
            ngModel.$validators.compareTo = function (modelValue) {
                console.log(modelValue == scope.otherModelValue)
                return modelValue == scope.otherModelValue;
            };
            scope.$watch("otherModelValue", function () {
                ngModel.$validate();
            });
        }
    };
});
