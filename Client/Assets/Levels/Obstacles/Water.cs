using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Obstacles
{
    class Water : Obstacle
    {
        public Water(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkBlue;
        }
    }
}
