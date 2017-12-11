using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BPS.HiltonDirect.WebApp.Hubs
{
    [HubName("dashboards")]
    public class DashboardHub : Hub
    {
        public static void ReloadRequestList()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<DashboardHub>();
            context.Clients.All.displayStatus();
        }
    }
}