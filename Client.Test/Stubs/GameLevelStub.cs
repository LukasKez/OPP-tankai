using System;

namespace Client
{
    class GameLevelStub : GameLevel
    {
        public GameLevelStub() : base(1, 1, 1, 1, 0)
        {
            GameState.Instance.gameLevel = this;
        }
    }
}
