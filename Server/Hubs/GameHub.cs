using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public static class UserHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }

    public class GameHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            foreach (var connectionId in UserHandler.ConnectedIds)
            {
                Clients.Caller.SendAsync("OnNewConnection", connectionId);
            }

            UserHandler.ConnectedIds.Add(Context.ConnectionId);

            Clients.Others.SendAsync("OnNewConnection", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            Clients.Others.SendAsync("OnDisconnectedConnection", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendPositionUpdate(float x, float y, float r)
        {
            await Clients.Others.SendAsync("OnPositionUpdate", Context.ConnectionId, x, y, r);
        }
    }
}
