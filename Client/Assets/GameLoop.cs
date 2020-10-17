﻿using Client.Assets.Levels;
using System;
using System.Windows.Forms;

namespace Client
{
    public static class GameLoop
    {
        public static float DeltaTime { get; private set; }
        public static int fps;

        static int frames;
        static DateTime lastTime;

        static DateTime startTime = DateTime.Now;
        static DateTime endTime = DateTime.Now;

        public static void StartGame(string levelType = "forest")
        {
            var state = GameState.Instance;
            state.gameLevel = GameLevelCreator.GetGameLevel(
                levelType, (float)state.mapSize.X, (float)state.mapSize.Y, 20, 20, 2);

            GameObject.Instantiate(new LocalPlayer());
            //GameObject.Instantiate(new Bot());

            GameState.Instance.State = ClientState.Playing;
        }

        public static void Manage(PaintEventArgs e)
        {
            if (GameState.Instance.State != ClientState.Playing)
            {
                return;
            }

            endTime = DateTime.Now;
            DeltaTime = (endTime.Ticks - startTime.Ticks) / (float)(TimeSpan.TicksPerSecond);
            startTime = endTime;

            Update(DeltaTime);
            Render(e);
        }

        static void Update(float deltaTime)
        {
            UpdateFPS();
            GameState.Instance.gameLevel.Update(deltaTime);
        }

        static void Render(PaintEventArgs e)
        {
            GameState.Instance.gameLevel.Render(e);
        }

        static void UpdateFPS()
        {
            frames++;

            if ((startTime - lastTime).TotalSeconds >= 0.5)
            {
                fps = frames * 2;
                frames = 0;
                lastTime = DateTime.Now;
            }
        }
    }
}
