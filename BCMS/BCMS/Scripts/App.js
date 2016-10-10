$(document).ready(function () {
    var con = $.connection.hitLogOffHub;
 
    con.client.sendPrivateMessage = function (id,message) {
        if (message != null) {
            var url = "/Account/AdminMessage";
            window.location.href = url;
        }
    };
    $.connection.hub.start();
    
});