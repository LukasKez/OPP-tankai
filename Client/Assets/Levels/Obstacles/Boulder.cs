using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Obstacles
{
    class Boulder : Obstacle
    {
        public Boulder(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }

        public override void Render(PaintEventArgs e)
        {
            Renderer.Ellipse(e, Brushes.DarkGray, transform);
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
