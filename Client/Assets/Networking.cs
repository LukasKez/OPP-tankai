using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

namespace Client
{
    public struct PlayerStats
    {
        public string name { get; set; }
        public bool isReady { get; set; }
    }

    public struct ProjectileStats
    {
        public float damage { get; set; }
        public float speed { get; set; }
        public int bounceCount { get; set; }
        public float bounceAngle { get; set; }
    }

    static class Networking
    {
        public static string scheme = "http://";
        public static string host = "localhost:52620";
        public static string path = "/gamehub";

        private static ConcurrentDictionary<string, RemotePlayer> remotePlayers;
        private static HubConnection connection;

        public static event Action<int, RemotePlayer> OnRemotePlayersChange;
        public static event Action<LevelType> OnLevelTypeChange;

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

            connection.On<DateTime, LevelType, int>("StartGame", (startAt, levelType, spawnPos) =>
            {
                GameLoop.StartGame(startAt, levelType, spawnPos);
                foreach (var player in remotePlayers)
                {
                    player.Value.Spawn();
                    GameObject.Instantiate(player.Value);
                }
            });

            connection.On<string, PlayerStats>("OnNewConnection", (connectionId, stats) =>
            {
                if (connectionId == connection.ConnectionId)
                    return;

                RemotePlayer player = new RemotePlayer()
                {
                    name = stats.name,
                    isReady = stats.isReady,
                };

                if (remotePlayers.TryAdd(connectionId, player))
                {
                    RemotePlayerChange(remotePlayers.Count - 1, player);
                    GameObject.Instantiate(player);
                }
            });

            connection.On<string>("OnDisconnectedConnection", (connectionId) =>
            {
                if (connectionId == connection.ConnectionId)
                    return;

                int index = FindIndex(connectionId);
                if (remotePlayers.TryRemove(connectionId, out RemotePlayer player))
                {
                    RemotePlayerChange(index, null);
                    player.Despawn();
                    player.Destroy();
                }
            });

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Debug.WriteLine($"{user}: {message}");
            });

            connection.On<string, string>("OnSetName", (connectionId, name) =>
            {
                if (remotePlayers.TryGetValue(connectionId, out RemotePlayer player))
                {
                    player.name = name;
                    RemotePlayerChange(FindIndex(connectionId), player);
                }
            });

            connection.On<string, bool>("OnSetIsReady", (connectionId, isReady) =>
            {
                if (remotePlayers.TryGetValue(connectionId, out RemotePlayer player))
                {
                    player.isReady = isReady;
                    RemotePlayerChange(FindIndex(connectionId), player);
                }
            });

            connection.On<LevelType>("OnSetLevelType", (levelType) =>
            {
                LevellTypeChange(levelType);
            });

            connection.On<float, float, float, ProjectileStats>("OnCreateProjectile", (x, y, r, stats) =>
            {
                Transform tr = new Transform()
                {
                    position = new Vector2(x, y),
                    rotation = r,
                };

                Projectile projectile = new Projectile(tr)
                {
                    damage = stats.damage,
                    speed = stats.speed,
                    bounceAngle = stats.bounceAngle,
                    bounceCount = stats.bounceCount,
                };

                projectile.SetPosition(tr);
                GameObject.Instantiate(projectile);
            });

            connection.On<string, float, float, float, float>("OnPositionUpdate", (connectionId, x, y, r1, r2) =>
            {
                if (remotePlayers.TryGetValue(connectionId, out RemotePlayer player))
                {
                    player.SetPosition(x, y, r1, r2);
                }
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
            catch (Exception e)
            {
                GameState.Instance.State = ClientState.Menu;
                Debug.WriteLine("Error connecting: " + e.Message);
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
            catch (Exception e)
            {
                Debug.WriteLine("Error disconnecting: " + e.Message);
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
            catch (Exception e)
            {
                Debug.WriteLine("Error sending message: " + e.Message);
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
            catch (Exception e)
            {
                Debug.WriteLine("Error setting player name: " + e.Message);
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
            catch (Exception e)
            {
                if (GameState.Instance.State == ClientState.Ready)
                    GameState.Instance.State = ClientState.Connected;
                Debug.WriteLine("Error setting ready state: " + e.Message);
            }
        }

        public static async void SetLevelType(LevelType levelType)
        {
            if (!IsConnected())
                return;

            try
            {
                await connection.InvokeAsync("SetLevelType", levelType);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error setting level type: " + e.Message);
            }
        }

        public static async void CreateProjectile(Projectile projectile)
        {
            if (!IsConnected())
                return;

            try
            {
                Transform tr = projectile.transform;
                var stats = new ProjectileStats()
                {
                    damage = projectile.damage,
                    speed = projectile.speed,
                    bounceAngle = projectile.bounceAngle,
                    bounceCount = projectile.bounceCount,
                };

                await connection.InvokeAsync("CreateProjectile", tr.position.X, tr.position.Y, tr.rotation, stats);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error sending projectile update: " + e.Message);
            }
        }

        public static async void SendPositionUpdateAsync(Tank tank)
        {
            if (!IsConnected())
                return;

            try
            {
                Transform tr = tank.transform;
                float turetRot = tank.turret.transform.rotation;
                await connection.SendAsync("SendPositionUpdate", tr.position.X, tr.position.Y, tr.rotation, turetRot);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error sending position update: " + e.Message);
            }
        }

        public static bool IsConnected()
        {
            return connection?.State == HubConnectionState.Connected;
        }

        private static void RemotePlayerChange(int index, RemotePlayer player)
        {
            OnRemotePlayersChange?.Invoke(index, player);
        }

        private static void LevellTypeChange(LevelType levelType)
        {
            OnLevelTypeChange?.Invoke(levelType);
        }

        private static int FindIndex(string id)
        {
            int i = 0;
            foreach (var item in remotePlayers)
            {
                if (id == item.Key)
                    return i;

                i++;
            }
            return -1;
        }
    }
}
