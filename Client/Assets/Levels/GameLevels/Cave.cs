using System.Drawing;

namespace Client
{
    public class Cave : GameLevel
    {
        public Cave(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
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
