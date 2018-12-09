using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRChatClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                 .WithUrl("https://localhost:44362/TextContentMessageInput")
                 .Build();
            await connection.StartAsync();

            await connection.SendAsync("TextContentMessageInput", "halo");

        }
    }
}
