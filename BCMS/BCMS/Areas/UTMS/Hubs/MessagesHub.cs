﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Configuration;

namespace BCMS.Areas.UTMS.Hubs
{


    [HubName("MessagesHub")]
    public class MessagesHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["BorsaCapitalDataModel"].ToString();
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("sendMessages")]
        public static void SendMessages()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
            context.Clients.All.updateMessages();
        }

    }
}