using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public static class GameHandler
    {
        public class PlayerStats
        {
            public string name;
            public bool isReady;
        }

        public static ConcurrentDictionary<string, PlayerStats> players =
            new ConcurrentDictionary<string, PlayerStats>();
        public static int maxPlayerCount = 4;
        public static bool isGameStarted;
    }

    public class GameHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            if (GameHandler.isGameStarted || GameHandler.players.Count > GameHandler.maxPlayerCount)
            {
                Clients.Caller.SendAsync("DisconnectClient");
                return base.OnConnectedAsync();
            }

            foreach (var player in GameHandler.players)
            {
                Clients.Caller.SendAsync("OnNewConnection", player.Key);
                Clients.Caller.SendAsync("OnSetName", player.Key, player.Value.name);
                Clients.Caller.SendAsync("OnSetReady", player.Key, player.Value.isReady);
            }

            GameHandler.players.TryAdd(Context.ConnectionId, new GameHandler.PlayerStats());

            Clients.Others.SendAsync("OnNewConnection", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            GameHandler.players.TryRemove(Context.ConnectionId, out _);
            if (GameHandler.players.Count == 0)
                GameHandler.isGameStarted = false;

            Clients.Others.SendAsync("OnDisconnectedConnection", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SetName(string name)
        {
            GameHandler.players[Context.ConnectionId].name = name;

            await Clients.Others.SendAsync("OnSetName", Context.ConnectionId, name);
        }

        public async Task SetIsReady(bool isReady)
        {
            GameHandler.players[Context.ConnectionId].isReady = isReady;

            await Clients.Others.SendAsync("OnSetIsReady", Context.ConnectionId, isReady);

            if (!GameHandler.players.All(player => player.Value.isReady))
                return;

            GameHandler.isGameStarted = true;
            DateTime startAt = DateTime.UtcNow.AddSeconds(5);
            await Clients.All.SendAsync("StartGame", startAt);
        }

        public async Task SendPositionUpdate(float x, float y, float r)
        {
            await Clients.Others.SendAsync("OnPositionUpdate", Context.ConnectionId, x, y, r);
        }
    }
}
