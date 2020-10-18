using System;
using System.Drawing;

namespace Client
{
    class ObstacleBuilder : IObstacleBuilder
    {
        Obstacle obstacle;

        public Obstacle GetObstacle()
        {
            return obstacle;
        }

        public IObstacleBuilder MakeNewGameObject(float x, float y, float blockWidth, float blockHeight)
        {
            obstacle = new Obstacle(x, y, blockWidth, blockHeight);
            return this;
        }

        public IObstacleBuilder SetBrush(Brush brush)
        {
            obstacle.brush = brush;
            return this;
        }

        public IObstacleBuilder SetShape(Shape shape)
        {
            obstacle.shape = shape;
            return this;
        }

        IObstacleBuilder IObstacleBuilder.SetSizeModifier(float modifier)
        {
            obstacle.transform.size.X = obstacle.transform.size.X * modifier;
            obstacle.transform.size.Y = obstacle.transform.size.Y * modifier;

            return this;
        }
    }
}
