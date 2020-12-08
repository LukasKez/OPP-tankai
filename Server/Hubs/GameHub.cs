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
        public struct PlayerStats
        {
            public string name { get; set; }
            public bool isReady { get; set; }
            public int tankType { get; set; }
        }

        public struct ProjectileStats
        {
            public float damage { get; set; }
            public float speed { get; set; }
            public int bounceCount { get; set; }
            public float bounceAngle { get; set; }
        }

        public static ConcurrentDictionary<string, PlayerStats> players =
            new ConcurrentDictionary<string, PlayerStats>();
        public static int maxPlayerCount = 4;
        public static bool isGameStarted;
        public static int levelType;
    }

    public class GameHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            if (GameHandler.isGameStarted || GameHandler.players.Count > GameHandler.maxPlayerCount)
            {
                await Clients.Caller.SendAsync("DisconnectClient");
                await base.OnConnectedAsync();
                return;
            }

            foreach (var player in GameHandler.players)
            {
                await Clients.Caller.SendAsync("OnNewConnection", player.Key, player.Value);
            }

            if (!GameHandler.isGameStarted)
                await Clients.Caller.SendAsync("OnSetLevelType", GameHandler.levelType);

            GameHandler.PlayerStats stats = new GameHandler.PlayerStats();
            GameHandler.players.TryAdd(Context.ConnectionId, stats);

            await Clients.Others.SendAsync("OnNewConnection", Context.ConnectionId, stats);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            GameHandler.players.TryRemove(Context.ConnectionId, out _);
            if (GameHandler.players.Count == 0)
                GameHandler.isGameStarted = false;

            await Clients.Others.SendAsync("OnDisconnectedConnection", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string name, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", name, message);
        }

        public async Task SetName(string name)
        {
            var stats = GameHandler.players[Context.ConnectionId];
            stats.name = name;
            GameHandler.players[Context.ConnectionId] = stats;

            await Clients.Others.SendAsync("OnSetName", Context.ConnectionId, name);
        }

        public async Task SetIsReady(bool isReady)
        {
            var stats = GameHandler.players[Context.ConnectionId];
            stats.isReady = isReady;
            GameHandler.players[Context.ConnectionId] = stats;

            await Clients.Others.SendAsync("OnSetIsReady", Context.ConnectionId, isReady);

            if (!GameHandler.players.All(player => player.Value.isReady))
                return;

            GameHandler.isGameStarted = true;
            DateTime startAt = DateTime.UtcNow.AddSeconds(5);

            int i = 0;
            foreach (var player in GameHandler.players)
            {
                await Clients.Client(player.Key).SendAsync("StartGame", startAt, GameHandler.levelType, i++);
            }
        }

        public async Task SetTankType(int type)
        {
            var stats = GameHandler.players[Context.ConnectionId];
            stats.tankType = type;
            GameHandler.players[Context.ConnectionId] = stats;

            await Clients.Others.SendAsync("OnSetTankType", Context.ConnectionId, type);
        }

        public async Task SetLevelType(int levelType)
        {
            if (GameHandler.isGameStarted)
                return;

            GameHandler.levelType = levelType;

            await Clients.Others.SendAsync("OnSetLevelType", levelType);
        }

        public async Task CreateProjectile(float x, float y, float r, GameHandler.ProjectileStats stats)
        {
            await Clients.Others.SendAsync("OnCreateProjectile", x, y, r, stats);
        }

        public async Task SendPositionUpdate(float x, float y, float r1, float r2)
        {
            await Clients.Others.SendAsync("OnPositionUpdate", Context.ConnectionId, x, y, r1, r2);
        }
    }
}
