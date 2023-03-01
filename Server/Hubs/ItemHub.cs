using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Server.Models;
using Server.Services;
using Server.Repositories;

namespace Server.Hubs
{
    public class ItemHub : Hub
    {
        // public async Task InitData(string connectionId, List<Item>? data, string userid = "")
        //     => await Clients.Client(connectionId).SendAsync("initData", data);

        public async Task InitData(string connectionId, string userid){
            ItemRepository repository = new();
            Console.WriteLine($"InitData UserId {userid} ConnectionId {connectionId}");
            await Clients.Client(connectionId).SendAsync("initData", repository.Get(userid));
        }
    

        public string GetConnectionId() => Context.ConnectionId;
        public string AddConnectedUser(string userid)
        {
            bool ans = ConnectionManager.Add(userid, Context.ConnectionId);
            return ans ? "Success" : "Fail";
        }
        public override Task OnDisconnectedAsync(Exception? exception){
            string connectionId = Context.ConnectionId;
            ConnectionManager.Remove(connectionId);
            return base.OnDisconnectedAsync(exception);
        }

    }
}