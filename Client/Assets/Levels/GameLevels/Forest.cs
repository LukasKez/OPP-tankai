using PowerUp;
using System.Drawing;

namespace Client
{
    public class Forest : GameLevel
    {
        public Forest(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {


            // Add PowerUp spawners
            stuff.Add(new PowerUpSpawner(blockWidth * 7, blockHeight * 4, blockWidth, blockWidth, new RandomSpawn()));
        }

        public override void SetUpGround(IVisitor v)
        {
            Accept(v);
            visitor.Visit(this);
        }
        public override void SetUpBorders(IVisitor v)
        {
            Accept(v);
            visitor.Visit(this);
        }
        public override void SetUpObstacles(IVisitor v)
        {
            Accept(v);
            visitor.Visit(this);
        }

        public override void SetUpSpawners(IVisitor v)
        {
            Accept(v);
            visitor.Visit(this);
        }
    }
}
