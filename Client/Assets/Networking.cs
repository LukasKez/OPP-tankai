using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Networking
    {
        public static string url = "http://localhost:52620/gamehub";

        private static Dictionary<string, RemotePlayer> remotePlayers;
        private static HubConnection connection;

        public static async void ConnectAsync()
        {
            remotePlayers = new Dictionary<string, RemotePlayer>();

            connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("OnNewConnection", (connectionId) =>
            {
                if (connectionId == connection.ConnectionId)
                    return;

                RemotePlayer player = new RemotePlayer();
                remotePlayers.Add(connectionId, player);
            });

            connection.On<string>("OnDisconnectedConnection", (connectionId) =>
            {
                if (connectionId == connection.ConnectionId)
                    return;

                remotePlayers.Remove(connectionId);
            });

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Debug.WriteLine($"{user}: {message}");
            });

            connection.On<string, float, float, float>("OnPositionUpdate", (connectionId, x, y, r) =>
            {
                if (!remotePlayers.ContainsKey(connectionId))
                    return;

                remotePlayers[connectionId].UpdatePosition(x, y, r);
            });

            try
            {
                await connection.StartAsync();
                Debug.WriteLine("Connection started");
            }
            catch
            {
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

        public static void Update(float deltaTime)
        {
            foreach (var player in remotePlayers)
            {
                player.Value.Update(deltaTime);
            }
        }

        public static void Render(PaintEventArgs e)
        {
            foreach (var player in remotePlayers)
            {
                player.Value.Render(e);
            }
        }
    }
}
