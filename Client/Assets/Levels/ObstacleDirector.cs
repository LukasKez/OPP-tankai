using Client.Assets.Levels.Obstacles;
using Client.Obstacles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assets.Levels
{
    class ObstacleDirector
    {

        private IBuilder obstacleBuilder;
        public ObstacleDirector(IBuilder obstacleBuilder)
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
