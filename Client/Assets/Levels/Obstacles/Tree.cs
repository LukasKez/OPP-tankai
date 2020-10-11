using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Obstacles
{
    class Tree : Obstacle
    {
        public Tree(float x,float y,float width,float height) 
            : base(x,y,width, height)
        {
            shape = Shape.Ellipse;
            brush = Brushes.DarkGreen;
        }
    }
}
