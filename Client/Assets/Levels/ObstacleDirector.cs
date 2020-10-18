using System.Drawing;

namespace Client
{
    class ObstacleDirector
    {
        private IObstacleBuilder obstacleBuilder;

        public ObstacleDirector(IObstacleBuilder obstacleBuilder)
        {
            this.obstacleBuilder = obstacleBuilder;
        }

        public void ConstructTree(float x, float y, float blockWidth, float blockHeight)
        {
            obstacleBuilder.MakeNewGameObject(x, y, blockWidth, blockHeight).
                SetSizeModifier(1.5f).SetBrush(Brushes.DarkGreen).SetShape(Shape.Ellipse);
        }

        public void ConstructBoulder(float x, float y, float blockWidth, float blockHeight)
        {
            obstacleBuilder.MakeNewGameObject(x, y, blockWidth, blockHeight).
                SetSizeModifier(1).SetBrush(Brushes.DarkGray).SetShape(Shape.Ellipse);
        }

        public void ConstructWater(float x, float y, float blockWidth, float blockHeight)
        {
            obstacleBuilder.MakeNewGameObject(x, y, blockWidth, blockHeight).
                SetSizeModifier(1).SetBrush(Brushes.DarkSlateBlue).SetShape(Shape.Rectangle);
        }

        public void ConstructWall(float x, float y, float blockWidth, float blockHeight)
        {
            obstacleBuilder.MakeNewGameObject(x, y, blockWidth, blockHeight).
                SetSizeModifier(0.5f).SetBrush(Brushes.DarkSlateGray).SetShape(Shape.Rectangle);
        }
    }
}
