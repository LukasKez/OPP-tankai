using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Client
{
    class Rectangle
    {
        public Rectangle()
        {
        }

        public void Draw(PaintEventArgs e, Brush brush, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.FillRectangle(brush, position.X, position.Y, size.X, size.Y);
        }

        public void Draw(PaintEventArgs e, Pen pen, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.DrawRectangle(pen, position.X, position.Y, size.X, size.Y);
        }
    }
}
