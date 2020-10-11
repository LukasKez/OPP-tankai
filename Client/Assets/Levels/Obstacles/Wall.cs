using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Obstacles
{
    class Wall : Obstacle
    {
        public Wall(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkSlateGray;
        }
    }
}
