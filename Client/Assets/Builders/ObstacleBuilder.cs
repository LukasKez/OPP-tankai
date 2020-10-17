using Client.Assets.Levels.Obstacles;
using Client.Obstacles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assets.Levels.ObstacleBuilders
{
    class ObstacleBuilder : IBuilder
    {
        Obstacle obstacle;

        public Obstacle GetObstacle()
        {
            return obstacle;
        }

        public IBuilder MakeNewGameObject(float x, float y, float blockWidth, float blockHeight)
        {
            obstacle = new Obstacle(x, y, blockWidth, blockHeight);
            return this;
        }

        public IBuilder SetBrush(Brush brush)
        {
            obstacle.brush = brush;
            return this;
        }

        public IBuilder SetShape(Shape shape)
        {
            obstacle.shape = shape;
            return this;
        }

        IBuilder IBuilder.SetSizeModifier(float modifier)
        {
            obstacle.transform.size.X = obstacle.transform.size.X * modifier;
            obstacle.transform.size.Y = obstacle.transform.size.Y * modifier;

            return this;
        }
    }
}
