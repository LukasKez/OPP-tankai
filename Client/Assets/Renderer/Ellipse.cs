using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Client
{
    class Ellipse
    {
        public Ellipse()
        {
        }

        public void Draw(PaintEventArgs e, Brush brush, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.FillEllipse(brush, position.X, position.Y, size.X, size.Y);
        }

        public void Draw(PaintEventArgs e, Pen pen, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.DrawEllipse(pen, position.X, position.Y, size.X, size.Y);
        }
    }
}
