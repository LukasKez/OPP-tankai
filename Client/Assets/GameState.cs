using System;
using System.Windows;

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

    class GameState
    {
        public bool focused;
        public Vector mapSize;
        public GameLevel gameLevel;

        private ClientState state;
        public ClientState State
        {
            get { return state; }
            set
            {
                state = value;
                GameObserver.GameStateChange(value);
            }
        }

        private static readonly GameState instance = new GameState();
        public static GameState Instance
        {
            get { return instance; }
        }

        public GameState()
        {
            mapSize = new Vector(800, 600);
        }
    }
}
