// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using Server.Models;

Console.WriteLine("Hello, World!");
MainAsync().Wait();
Console.ReadLine();

static async Task MainAsync(){
    string connectionId = "";
    Console.Write("Enter userid:");

    string userid = Console.ReadLine()??"giang";
    HubConnection hubConnection = new HubConnectionBuilder()
        .WithUrl(new Uri("http://localhost:5041/item"))
        //.WithAutomaticReconnect(new RandomRetryPolicy())
        .Build();

    hubConnection.On<List<Item>>("initData", (data) =>
    {
        Console.WriteLine("initData " + DateTime.Now.ToString());
        PrintItem(data);
    });


    hubConnection.On<List<Item>>("refreshData", (data) =>
    {
        Console.WriteLine("refreshData " + DateTime.Now.ToString());
        PrintItem(data);
    });

    await hubConnection.StartAsync();

    connectionId = hubConnection.InvokeAsync<string>("GetConnectionId").Result;
    Console.WriteLine($"UserId {userid} ConnectionId {connectionId}");
    string ans = hubConnection.InvokeAsync<string>("AddConnectedUser", userid).Result;
    Console.WriteLine($"AddConnectedUser {ans}");

    Console.WriteLine("InitData");
    await hubConnection.SendAsync("InitData", connectionId, userid);
}


static void PrintItem(List<Item> data){
    foreach(var item in data){
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine();
}