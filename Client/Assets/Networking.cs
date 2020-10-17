using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Client
{
    static class Networking
    {
        public static string scheme = "http://";
        public static string host = "localhost:52620";
        public static string path = "/gamehub";

        private static ConcurrentDictionary<string, RemotePlayer> remotePlayers;
        private static HubConnection connection;

        static Networking()
        {
            remotePlayers = new ConcurrentDictionary<string, RemotePlayer>();
        }

        public static async void ConnectAsync()
        {
            if (IsConnected())
                return;

            remotePlayers.Clear();

            connection = new HubConnectionBuilder()
                .WithUrl(scheme + host + path)
                .WithAutomaticReconnect()
                .Build();

            connection.Closed += (error) =>
            {
                GameState.Instance.State = ClientState.Menu;
                return Task.CompletedTask;
            };

            connection.On<DateTime>("StartGame", (startAt) =>
            {
                GameLoop.StartGame();
                foreach (var remotePlayer in remotePlayers)
                {
                    remotePlayer.Value.Spawn();
                }
            });

            connection.On<string>("OnNewConnection", (connectionId) =>
            {
                if (connectionId == connection.ConnectionId)
                    return;

                remotePlayers.TryAdd(connectionId, new RemotePlayer());
            });

            connection.On<string>("OnDisconnectedConnection", (connectionId) =>
            {
                if (connectionId == connection.ConnectionId)
                    return;

                if (!remotePlayers.ContainsKey(connectionId))
                    return;

                remotePlayers[connectionId].Despawn();
                remotePlayers.TryRemove(connectionId, out _);
            });

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Debug.WriteLine($"{user}: {message}");
            });

            connection.On<string, string>("OnSetName", (connectionId, name) =>
            {
                if (!remotePlayers.ContainsKey(connectionId))
                    return;

                remotePlayers[connectionId].name = name;
            });

            connection.On<string, bool>("OnSetIsReady", (connectionId, isReady) =>
            {
                if (!remotePlayers.ContainsKey(connectionId))
                    return;

                remotePlayers[connectionId].isReady = isReady;
            });

            connection.On<string, float, float, float>("OnPositionUpdate", (connectionId, x, y, r) =>
            {
                if (!remotePlayers.ContainsKey(connectionId))
                    return;

                remotePlayers[connectionId].UpdatePosition(x, y, r);
            });

            connection.On("DisconnectClient", () =>
            {
                DisconnectAsync();
            });

            try
            {
                await connection.StartAsync();
                SetNameAsync(Options.name);

                GameState.Instance.State = ClientState.Connected;
                Debug.WriteLine("Connection started");
            }
            catch
            {
                GameState.Instance.State = ClientState.Menu;
                Debug.WriteLine("Error connecting");
            }
        }

        public static async void DisconnectAsync()
        {
            if (!IsConnected())
                return;

            try
            {
                await connection.StopAsync();
                Debug.WriteLine("Connection stopped");
            }
            catch
            {
                Debug.WriteLine("Error disconnecting");
            }
        }

        public static async void SendMessageAsync(string name, string message)
        {
            if (!IsConnected())
                return;

            try
            {
                await connection.InvokeAsync("SendMessage", name, message);
            }
            catch
            {
                Debug.WriteLine("Error sending message");
            }
        }

        public static async void SetNameAsync(string name)
        {
            if (!IsConnected())
                return;

            try
            {
                await connection.InvokeAsync("SetName", name);
            }
            catch
            {
                Debug.WriteLine("Error setting player name");
            }
        }

        public static async void SetIsReadyAsync(bool isReady)
        {
            if (!IsConnected())
                return;

            try
            {
                await connection.InvokeAsync("SetIsReady", isReady);
            }
            catch
            {
                if (GameState.Instance.State == ClientState.Ready)
                    GameState.Instance.State = ClientState.Connected;
                Debug.WriteLine("Error setting ready state");
            }
        }

        public static async void SendPositionUpdateAsync(GameObject player)
        {
            if (!IsConnected())
                return;

            try
            {
                Transform tr = player.transform;
                await connection.SendAsync("SendPositionUpdate", tr.position.X, tr.position.Y, tr.rotation);
            }
            catch
            {
                Debug.WriteLine("Error sending position update");
            }
        }

        public static bool IsConnected()
        {
            return connection?.State == HubConnectionState.Connected;
        }
    }
}
