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
                NewConnection.Time = DateTime.Now;
                db.Connections.Add(NewConnection);
                db.SaveChanges();
           
            }
            else
            {
                Clients.Client(UserConnection.ConnectionId).logoff();
                Connection NewConnection = new Connection();
                NewConnection.UserId = UserId;
                NewConnection.ConnectionId = Context.ConnectionId;
                NewConnection.Email = Context.User.Identity.GetUserName();
                NewConnection.Time = DateTime.Now;
                db.Connections.Add(NewConnection);
                db.SaveChanges();
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