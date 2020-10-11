using System;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public class GameLoop
    {
        public float DeltaTime { get; private set; }
        public int fps;

        int frames;
        DateTime lastTime;

        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now;

        public GameLoop()
        {
            Networking.ConnectAsync();
        }

        public void StartGame()
        {
            GameState.Instance.gameLevel.Add(new LocalPlayer());
            GameState.Instance.gameLevel.Add(new Bot());

            GameState.Instance.state = State.playing;
        }

        public void Manage(PaintEventArgs e)
        {
            if (GameState.Instance.state != State.playing)
            {
                return;
            }

            endTime = DateTime.Now;
            DeltaTime = (endTime.Ticks - startTime.Ticks) / (float)(TimeSpan.TicksPerSecond);
            startTime = endTime;

            Update(DeltaTime);
            Render(e);
        }

        void Update(float deltaTime)
        {
            UpdateFPS();
            GameState.Instance.gameLevel.Update(deltaTime);
            Networking.Update(deltaTime);
        }

        void Render(PaintEventArgs e)
        {
            GameState.Instance.gameLevel.Render(e);
            Networking.Render(e);
        }

        void UpdateFPS()
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
