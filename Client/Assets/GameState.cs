using Client.Assets.Levels.GameLevels;
using System;
using System.Windows;

namespace Client
{
    public enum State
    {
        menu,
        pending,
        playing,
        died,
    }

    class GameState
    {
        public State state;
        public bool focused;
        public Vector mapSize;
        public GameLevel gameLevel;

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
