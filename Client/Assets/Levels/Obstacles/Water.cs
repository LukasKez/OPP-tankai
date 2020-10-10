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
        }

        public override void Render(PaintEventArgs e)
        {
            Renderer.Rectangle(e, Brushes.DarkBlue, transform);
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
