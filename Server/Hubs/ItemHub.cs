using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class ItemHub : Hub
    {
        // public async Task BroadcastChartData(List<ChartModel> data, string connectionId) => 
        //     await Clients.Client(connectionId).SendAsync("broadcastchartdata", data);

        public string GetConnectionId() => Context.ConnectionId;
    }
}