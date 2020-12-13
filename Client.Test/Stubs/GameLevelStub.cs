using System;

namespace Client
{
    class GameLevelStub : GameLevel
    {
        public GameLevelStub() : base(1, 1, 1, 1, 0)
        {
            GameState.Instance.gameLevel = this;
        }

        public override void SetUpBorders(IVisitor v)
        {
            throw new NotImplementedException();
        }

        public override void SetUpGround(IVisitor v)
        {
            throw new NotImplementedException();
        }

        public override void SetUpObstacles(IVisitor v)
        {
            throw new NotImplementedException();
        }

        public override void SetUpSpawners(IVisitor v)
        {
            throw new NotImplementedException();
        }
    }
}
