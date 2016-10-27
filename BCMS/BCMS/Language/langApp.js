/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/angular.js" />
/// <reference path="C:\Users\hany\Documents\Visual Studio 2015\Projects\BCMS\BCMS\Scripts/angular-translate.js" />

var langApp = angular.module("langApp", ['MyApp', 'pascalprecht.translate', 'ngCookies']);

langApp.config(["$translateProvider", function ($translateProvider) {

    $translateProvider.translations("en", {
        // Layout Header
        'login': 'Login',
        'register': 'Register',
        'logout': 'Logout',
        'welcome': 'Welcome',
        'pixel': 'Pixel Page',
        'feedback': 'Feedback',
        'onlineSupport': 'Online support',
        'search': 'Search',
        'home': 'Home',
        'about': 'About Us',
        'bcWord': 'Borsa Capital Word',
        'aboutKSA': 'About Saudi Arabia',
        'COMMON_QUESTIONS': 'Common Questions',
        'jobs': 'Jobs',
        'AVAILABLE_JOBS': 'Available Jobs',
        'pyramidServices': 'Pyramid Services',
        'download': 'Download',
        'demo': 'Demo Account',
        'partners': 'Partners',
        'contactus': 'Contact Us',

        // Layout Footer
        'bc': 'Borsa Capital',
        'sayingsOfWise': 'Sayings of wise',
        'ourServices': 'Our Services',
        'investmentAdvices': 'Investment advices',
        'education': 'Educations',
        'library': 'Library',
        'exams': 'Exams',
        'terminology': 'Terminology',
        'educationalVideos': 'Educational Videos',
        'educationalGames': 'Educational Games',
        'entertainment': 'Entertainment',
        'caricature': 'Caricature',
        'entertainmentGames': 'Entertainment Games',
        'music': 'Music',
        'videos': 'Videos',
        'siteMap': 'Site Map',
        'copyRights': 'Copyrights',

        // register
        'newUser': 'New User',
        'fullName': 'Full Name',
        'fName': 'First Name',
        'fNameValidaion': 'First name required',
        'mName': 'Middle Name',
        'lName': 'Last Name',
        'lNameValidation': 'Last name required',
        'USER_NAME': 'User Name',
        'USER_NAME_VALIDATION': 'User name required',
        'email': 'E-mail',
        'EMAIL_VALIDATION': 'E-mail required',
        'EMAIL_INCORRECT': 'Email is incorrect',
        'password': 'Password',
        'passwordValidation': 'Password required',
        'cPassword': 'Confirm password',
        'cPasswordValidation': 'Please confirm your password',
        'REGISTER_BUTTON': 'Register',

        // Login
        'LOGIN': 'Login',
        'REMEMBER_ME': 'Remember me',
        'FORGET_PASSWORD': 'Forgot Password',
        'CREATE_ACCOUNT': 'Create account',
        'MORE_INFORMATION': 'More Information',
        'LOGIN_BUTTON': 'Login',
        "DONT_HAVE_ACCOUNT":"Don't have account?",

        //contact us
        'CONTACT_US': 'Contact Us',
        'name': 'Name',
        'nameValidation': 'Name required',

        'TOPIC': 'Topic',
        'TOPIC_VALIDATION': 'Topic required ',
        'message': 'Message',
        'messageValidation': 'Message required',
        'capitha': 'Enter the Number',
        'SEND_BTN': 'Send',

        //feedback
        'FEEDBACK_TITLE': 'Your proposal concerns us',
        'FILL_FORM': 'Fill out the form and type your proposal',
        'SUGGEST': 'Suggestion',

        // Sponsors
        'OFFICIAL_SPONSORS': 'Official Sponsors',
        'DIAMOND_SPONSOR': 'Diamond Sponsor',
        'GOLDEN_SPONSOR': 'Golden Sonsor',
        'PLATINUM_SPONSOR': 'Platinum Sponsor',
        'SILVER_SPONSOR': 'Silver Sponsor',

        // Forgot Password
        'FORGOT_PASSWORD': 'Forgot Password',
        'PLZ_ENTER_EMAIL': 'Please enter your email address',

    });

    $translateProvider.translations("ar", {
        'login': 'تسجيل الدخول',
        'register': 'مستخدم جديد',
        'logout': 'تسجيل خروج',
        'welcome': 'مرحباً',
        'pixel': 'بكسلها معنا',
        'feedback': 'رأيك يهمنا',
        'onlineSupport': 'الدعم الفنى',
        'search': 'بحث',
        'home': 'الرئيسية',
        'about': 'نبذه عنا',
        'bcWord': 'كلمة بورصه كابيتال',
        'aboutKSA': 'نبذه عن المملكة العربية السعودية',

        'jobs': 'وظائف شاغرة',
        'AVAILABLE_JOBS': 'الوظائف المتاحة',
        'pyramidServices': 'هرم الخدمات',
        'download': 'تحميل',
        'demo': 'حساب تجريبى',
        'partners': 'شركاؤنا',
        'contactus': 'اتصل بنا',

        // Layout Footer
        'bc': 'بورصه كابيتال',
        'sayingsOfWise': 'من أقوال الحكماء',
        'ourServices': 'خدماتنا',
        'investmentAdvices': 'نصائح استثمارية',
        'education': 'تعـــليم',
        'library': 'المكتبة',
        'exams': 'الإمتحانات',
        'terminology': 'المصطلحات',
        'educationalVideos': 'فيديوهات تعليمية',
        'educationalGames': 'ألعاب تعليمية',
        'entertainment': 'تـــرفيه',
        'caricature': 'كاريكاتير',
        'entertainmentGames': 'ألعاب ترفيهية',
        'music': 'موسيقى',
        'videos': 'فيديوهات',
        'siteMap': 'خارطة الموقع',
        'copyRights': 'حقوق النشر',

        // register
        'newUser': 'مستخدم جديد',
        'fullName': 'الاسم بالكامل',
        'fName': 'الاسم الأول',
        'fNameValidaion': 'يجب إدخال الاسم الأول',
        'mName': 'اسم الأب',
        'lName': 'اسم العائلة',
        'lNameValidation': 'يجب ادخال اسم العائلة',
        'USER_NAME': 'إسم المستخدم',
        'USER_NAME_VALIDATION': 'يجب ادخال اسم المستخدم',
        'email': 'البريد الإلكتروني',
        'EMAIL_VALIDATION': 'يجب ادخال البريد الإلكتروني',
        'EMAIL_INCORRECT': 'البريد الإلكتروني غير صحيح',
        'password': 'كلمة المرور',
        'passwordValidation': 'يجب ادخال كلمة المرور',
        'cPassword': 'تأكيد كلمة المرور',
        'cPasswordValidation': 'يجب تأكيد كلمة المرور',
        'REGISTER_BUTTON': 'تسجيل',

        // Login
        'LOGIN': 'تسجيل الدخول',
        'REMEMBER_ME': 'تذكرنى',
        'FORGET_PASSWORD': 'نسيت كلمة المرور',
        'CREATE_ACCOUNT': 'مستخدم جديد',
        'MORE_INFORMATION': 'للمزيد من المعلومات',
        'LOGIN_BUTTON': 'دخـــول',
        "DONT_HAVE_ACCOUNT":"ليس لديك حساب؟",

        //contact us
        'CONTACT_US': 'تواصل معنا',
        'name': 'الإسم',
        'nameValidation': 'يجب ادخال الاسم',
        'EMAIL': 'البريد الإلكترونى',
        'EMAIL_VALIDATION': 'يجب إدخال البريد الالكترونى',
        'emailIncorrect': 'البريد الإلكتروني غير صحيح',
        'TOPIC': 'الموضوع',
        'TOPIC_VALIDATION': 'يجب ادخال الموضوع',
        'message': 'الرسالة',
        'messageValidation': 'يجب ادخال الرسالة',
        'capitha': 'ادخل الرقم',
        'SEND_BTN': 'إرسال',

        //feedback
        'FEEDBACK_TITLE': 'اقتراحك يهمنا',
        'FILL_FORM': 'املأ النموذج واكتب اقتراحك',
        'SUGGEST': 'الاقتراح',

        // Sponsors
        'OFFICIAL_SPONSORS': 'الرعاة الرسميون',
        'DIAMOND_SPONSOR': 'الراعى الماسى',
        'GOLDEN_SPONSOR': 'الراعى الذهبى',
        'PLATINUM_SPONSOR': 'الراعى البلاتينى',
        'SILVER_SPONSOR': 'الراعى الفضى',


        'COMMON_QUESTIONS': 'أسأله متكرره',

        // Forgot Password
        'FORGOT_PASSWORD': 'نسيت كلمة المرور',
        'PLZ_ENTER_EMAIL': 'من فضلك أدخل البريد الالكتروني',

    });

    //var $cookies;
    //angular.injector(['ngCookies']).invoke(['$cookies', function (_$cookies_) {
    //    $cookies = _$cookies_;
    //}]);
    var lang = getCookie('language');
    if (lang != "") {
        $translateProvider.preferredLanguage(lang);

    } else {
        $translateProvider.preferredLanguage("ar");

    }

}]);

function getCookie(CookieName) {
    var name = CookieName + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            var value = c.substring(name.length, c.length);
            return value;
        }
    }
    return "";
}
