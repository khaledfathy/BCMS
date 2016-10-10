
//<![CDATA[



var userIdMessage;
var hitLogOffHub = $.connection.HitLogOffHub;
hitLogOffHub.client.sendPrivateMessage = function (uid, message) {
 userIdMessage = message;

};
hitLogOffHub.server.sendMessageWithId();
$.connection.hub.start();

$(document).ready(function () {
    var methods = {
        effect: function () {
            var blinkIt = function () {
                $.fallr('blink');
                var url = "/Account/Login";
                window.location.href = url;
            };
            var shakeIt = function () {
                $.fallr('shake');

            };
            var x = 2;
            if (x == 2) {
                $.fallr('show', {
                    content: '<h4>عذرا سوف يتم الخروج</h4>',
                    position: 'center',
                    icon: 'star',
                    buttons: {
                        button1: { text: 'موافق', onclick: blinkIt },
                        //button2: { text: 'هز', onclick: shakeIt },
                        //button3: { text: 'الغاء' }
                    }
                });
            }



        },
    };

    //button trigger
    $('a[href^="#fallr-"]').click(function () {
        var id = $(this).attr('href').substring(7);
        methods[id].apply(this, [this]);
        return false;
    });

    // code expander
    $('#features pre').slideUp();
    $('a[href="#"]').click(function () { var index = ($(this).parent('p').index() - 2) / 3; console.log(index); $(this).parent('p').siblings('pre').eq(index).slideToggle(); return false; });

    // syntax highlighter
    hljs.tabReplace = '    ';
    hljs.initHighlightingOnLoad();
});

//]]>
