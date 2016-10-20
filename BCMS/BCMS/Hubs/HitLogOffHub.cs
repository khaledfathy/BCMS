using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using BCMS.Models;

namespace BCMS.Hubs
{
    //[HubName("hitLogged")]
    public class HitLogOffHub : Hub
    {
        //public static Guid? _usrid { get; set; }
        ////static List<LoggedUser> ConnectedUsers = new List<LoggedUser>();
        //public static string _connectionId { get; set; }
        //public override System.Threading.Tasks.Task OnConnected()
        //{
        //    var id = Context.ConnectionId;
        //    var message = id;
        //    if (LoggedUsers.Users.Count(x => x.ConnectionId == id) == 0)
        //    {
        //        var uid = from c in LoggedUsers.Users
        //                      where c.UserId ==_usrid
        //                      select c;
        //        // add connection Id In LoggedUsers
        //        LoggedUsers.Users.Add(new LoggedUser { ConnectionId = id });
        //        var connn = LoggedUsers.Users.Count(x => x.UserId==_usrid);
        //        if (LoggedUsers.Users.Count(x => x.UserId == _usrid) > 1)
        //        {
        //            Clients.Client(uid.First().ConnectionId.ToString()).sendPrivateMessage(_usrid, message);
        //        }
        //    }
        //    return base.OnConnected();
        //}
        //public void SendMessageWithId()
        //{
        //    Guid? toUserId = _usrid;
        //    //var toUser = LoggedUsers.Users.Where(x => x.UserId == toUserId).FirstOrDefault();
        //    var toUser = (from x in LoggedUsers.Users
        //                    where x.UserId == toUserId
        //                    select x).FirstOrDefault();
        //    var message = toUserId;
        //    if (toUser != null)
        //    {
        //        //Clients.Client(toUserId.ToString()).sendPrivateMessage(toUserId, message);
        //        //Clients.All.sendPrivateMessage(toUserId, message);
        //        //Clients.Caller.sendPrivateMessage(toUserId, message);
        //        //Clients.Client(toUserId.ToString()).sendPrivateMessage(message); 

        //    }

        //}
        //public void SendPrivateMessage(string toUserId, string message)
        //{

        //    string fromUserId = Context.ConnectionId;

        //    var toUser = LoggedUsers.Users.FirstOrDefault(x => x.ConnectionId == toUserId);
           

        //    if (toUser != null )
        //    {
        //        // send to 
        //        Clients.Client(toUserId).sendPrivateMessage(message);

        //        // send to caller user
        //        Clients.Caller.sendPrivateMessage(toUserId, message);
        //    }

        //}
        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{
        //    //var item = LoggedUsers.Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    var item = LoggedUsers.Users.FirstOrDefault(x => x.UserId == _usrid);
        //    if (item != null)
        //    {
        //        LoggedUsers.Users.Remove(item);
        //        var id = Context.ConnectionId;
        //        Clients.All.onUserDisconnected(id, item.UserId);
        //    }
        //    return base.OnDisconnected(stopCalled);
        //}
    }


    
  
}