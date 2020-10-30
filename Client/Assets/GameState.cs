using System;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    public enum ClientState
    {
        Menu,
        Connecting,
        Connected,
        Ready,
        Playing,
        Died,
    }

    class GameState : Subject
    {
        public bool focused;
        public Vector2 mapSize;
        public Vector2 mouseLocation;
        public GameLevel gameLevel;
        public int RandomSeed;

        private ClientState state;
        public ClientState State
        {
            get { return state; }
            set
            {
                state = value;
                Notify();
            }
        }

        public event Action<MouseButtons> OnMouseClicked;

        public void MouseClicked(MouseButtons button)
        {
            OnMouseClicked?.Invoke(button);
        }

        private static readonly GameState instance = new GameState();
        public static GameState Instance
        {
            get { return instance; }
        }

        public GameState()
        {
            mapSize = new Vector2(800, 600);
        }
    }
}
