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
        }

        public override void Render(PaintEventArgs e)
        {
            Renderer.Ellipse(e, Brushes.DarkGreen, transform);
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
