// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using Server.Models;

Console.WriteLine("Hello, World!");

string connectionId = "";
string userid = "giang";
HubConnection hubConnection = new HubConnectionBuilder()
    .WithUrl(new Uri("http://127.0.0.1:5000/itemhub"))
    //.WithAutomaticReconnect(new RandomRetryPolicy())
    .Build();
await hubConnection.StartAsync();

connectionId = hubConnection.InvokeAsync<string>("GetConnectionId").Result;
Console.WriteLine($"UserId {userid} ConnectionId {connectionId}");
string ans = hubConnection.InvokeAsync<string>("AddConnectedUser", userid).Result;
Console.WriteLine($"AddConnectedUser {ans}");

hubConnection.On<List<Item>>("initData", (data) =>
{
    PrintItem(data);
});


static void PrintItem(List<Item> data){
    foreach(var item in data){
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine();
}