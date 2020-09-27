using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        HubConnection connection;

        DateTime time1 = DateTime.Now;
        DateTime time2 = DateTime.Now;
        float elapsedTime = 0;

        private Tank playerTank;
        private Tank playerTank2;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;

            ConnectClientAsync();

            playerTank = new Tank(0, 0, 20, 20);
            playerTank2 = new Tank(0, 0, 20, 20);
        }

        async void ConnectClientAsync()
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:52620/gamehub").Build();
            Debug.WriteLine("con");

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                Debug.WriteLine("Reconnecting");
                await connection.StartAsync();
            };

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Debug.WriteLine($"{user}: {message}");
            });

            connection.On<float, float, float>("OnPositionUpdate", (x, y, r) =>
            {
                playerTank2.transform.position.X = x;
                playerTank2.transform.position.Y = y;
                playerTank2.transform.rotation = r;
            });

            try
            {
                await connection.StartAsync();
                Debug.WriteLine("Connection started");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error connecting");
            }
        }

        async void SendMessageAsync(string name, string message)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", name, message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error sending message");
            }
        }

        async void SendPositionUpdateAsync()
        {
            try
            {
                GameObject.Transform tr = playerTank.transform;
                await connection.InvokeAsync("SendPositionUpdate", tr.position.X, tr.position.Y, tr.rotation);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error sending position update");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            time2 = DateTime.Now;
            float deltaTime = (time2.Ticks - time1.Ticks) / (float)(TimeSpan.TicksPerSecond);
            time1 = time2;

            //base.OnPaint(e);
            Update(deltaTime);
            Render(e);
            Invalidate();
        }

        void Update(float deltaTime)
        {
            elapsedTime += deltaTime;
            if (elapsedTime > 0.03f)
            {
                elapsedTime -= 0.03f;
                SendPositionUpdateAsync();
            }

            if (!Focused) return;
            playerTank.Update(deltaTime);
        }

        void Render(PaintEventArgs e)
        {
            playerTank.Render(e);
            playerTank2.Render(e);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}

