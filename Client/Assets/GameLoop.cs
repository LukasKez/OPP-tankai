using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public static class GameLoop
    {
        public static float DeltaTime { get; private set; }
        public static int fps;

        static int frames;
        static DateTime lastTime;

        static DateTime startTime;
        static DateTime endTime;

        public static void StartGame(DateTime startAt, LevelType levelType = LevelType.Forest, int spawnPos = 0)
        {
            var state = GameState.Instance;
            state.RandomSeed = (int)startAt.Ticks;
            state.gameLevel = GameLevelCreator.GetGameLevel(
                levelType, state.mapSize.X, state.mapSize.Y, 20, 20, 2);

            var spawner = state.gameLevel.Find<PlayerSpawner>().ElementAtOrDefault(spawnPos);
            GameObject.Instantiate(new LocalPlayer(spawner));
            GameObject.Instantiate(new BotPlayer());

            startTime = DateTime.Now;
            GameState.Instance.State = ClientState.Playing;
        }

        public static void Manage(PaintEventArgs e)
        {
            if (GameState.Instance.State < ClientState.Playing)
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
            GameState.Instance.gameLevel.HandleCollisions();
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
