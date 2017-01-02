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
            try
            {
                var UserId = Context.User.Identity.GetUserId();
                //var IsAuthenticated = Context.User.Identity.IsAuthenticated;
                var SessionId = HttpContext.Current.Request.Cookies["SessionID"];
                if (SessionId != null)
                {
                    string CurrentSessionId = SessionId.Value;
                    var UserConnection = db.Connections.Where(a => a.UserId == UserId).FirstOrDefault();
                    // Login for First time 
                    if (UserConnection == null)
                    {
                        Connection NewConnection = new Connection();
                        NewConnection.UserId = UserId;
                        NewConnection.ConnectionId = Context.ConnectionId;
                        NewConnection.Email = Context.User.Identity.GetUserName();
                        NewConnection.Time = DateTime.Now;
                        NewConnection.TabsNumber = 1;
                        NewConnection.SessionId = CurrentSessionId;
                        db.Connections.Add(NewConnection);

                    }
                    // Login from another device
                    else if (UserConnection.SessionId != CurrentSessionId)
                    {
                        // logout user from previous device
                        Clients.Client(UserConnection.ConnectionId).logoff();


                        Connection NewConnection = new Connection();
                        NewConnection.UserId = UserId;
                        NewConnection.ConnectionId = Context.ConnectionId;
                        NewConnection.Email = Context.User.Identity.GetUserName();
                        NewConnection.Time = DateTime.Now;
                        NewConnection.TabsNumber = 1;
                        NewConnection.SessionId = CurrentSessionId;
                        db.Connections.Add(NewConnection);
                    }
                    // open new tab
                    else
                    {
                        UserConnection.TabsNumber++;
                    }

                    db.SaveChanges();
                }
                return base.OnConnected();
            }
            catch(Exception ex)
            {
                return base.OnConnected();
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            try
            {
                var UserId = Context.User.Identity.GetUserId();
                var IsAuthenticated = Context.User.Identity.IsAuthenticated;
                var UserConnection = db.Connections.Where(a => a.UserId == UserId).FirstOrDefault();
                if (UserConnection != null)
                {
                    if (UserConnection.TabsNumber == 1 || !IsAuthenticated)
                    {
                        db.Connections.Remove(UserConnection);
                    }
                    else
                    {
                        UserConnection.TabsNumber--;
                    }
                    db.SaveChanges();
                }

                return base.OnDisconnected(stopCalled);
            }
            catch (Exception ex)
            {
                return base.OnDisconnected(stopCalled);
            }
        }
    }
}