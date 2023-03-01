// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using Server.Models;

Console.WriteLine("Hello, World!");
MainAsync().Wait();
Console.ReadLine();

static async Task MainAsync()
{
    // init data
    string connectionId = "";
    string userid;

    Console.Write("Enter userid:");
    userid = Console.ReadLine() ?? "giang";

    // create connection
    HubConnection hubConnection = new HubConnectionBuilder()
        .WithUrl(new Uri("http://localhost:5041/item"))
        //.WithAutomaticReconnect(new RandomRetryPolicy())
        .Build();

    // when initData was sent from server, console data
    hubConnection.On<List<Item>>("initData", (data) =>
    {
        Console.WriteLine("initData " + DateTime.Now.ToString());
        PrintItem(data);
    });

    // when refreshData was sent from server, console data
    hubConnection.On<List<Item>>("refreshData", (data) =>
    {
        Console.WriteLine("refreshData " + DateTime.Now.ToString());
        PrintItem(data);
    });
    // start connect
    await hubConnection.StartAsync();

    // Add ConnectedUser to server
    connectionId = hubConnection.InvokeAsync<string>("GetConnectionId").Result;
    Console.WriteLine($"UserId {userid} ConnectionId {connectionId}");
    string ans = hubConnection.InvokeAsync<string>("AddConnectedUser", userid).Result;
    Console.WriteLine($"AddConnectedUser {ans}");

    // get init data
    Console.WriteLine("InitData");
    await hubConnection.SendAsync("InitData", connectionId, userid);
}

static void PrintItem(List<Item> data)
{
    foreach (var item in data)
    {
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine();
}