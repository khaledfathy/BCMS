using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BCMS.Models;
using Microsoft.AspNet.SignalR.Hubs;


namespace BCMS.Hubs
{
    [HubName("mainHub")]
    public class mainHub : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public HttpCookieCollection Cookies { get; }

        public override Task OnConnected()
        {
            var UserId = Context.User.Identity.GetUserId();


            var UserConnection = db.Connections.Where(a => a.UserId == UserId).FirstOrDefault();
            if (UserConnection == null)
            {
                Connection NewConnection = new Connection();
                NewConnection.UserId = UserId;
                NewConnection.ConnectionId = Context.ConnectionId;
                NewConnection.Email = Context.User.Identity.GetUserName();
                db.Connections.Add(NewConnection);
                db.SaveChanges();
                HttpCookieCollection CookieCollection = new HttpCookieCollection();
                HttpCookie cookie = new HttpCookie("Connected", "true");
                                cookie.Expires = DateTime.Now.AddYears(50);

                CookieCollection.Set(cookie);
                //cookie.Value = ;
                //Cookies.Set(cookie);

            }
            else
            {
                var Connected = HttpContext.Current.Request.Cookies["Connected"];
                if (Connected != null)
                {
                    Clients.Caller.anotherDeviceConnected();
                }
            }


            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var UserId = Context.User.Identity.GetUserId();

            var UserConnection = db.Connections.Where(a => a.UserId == UserId).FirstOrDefault();
            db.Connections.Remove(UserConnection);
            db.SaveChanges();
            return base.OnDisconnected(stopCalled);
        }
    }
}