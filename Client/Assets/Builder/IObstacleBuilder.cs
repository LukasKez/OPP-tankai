using System;
using System.Drawing;

namespace Client
{
    interface IObstacleBuilder
    {
        IObstacleBuilder SetSizeModifier(float modifier);
        IObstacleBuilder SetBrush(Brush brush);
        IObstacleBuilder SetShape(Shape shape);
        IObstacleBuilder MakeNewGameObject(float x, float y, float blockWidth, float blockHeight);
    }
}
