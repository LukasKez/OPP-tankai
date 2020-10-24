using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Rectangle
    {
        public Rectangle()
        {
        }

        public void Draw(PaintEventArgs e, Brush brush, Transform transform)
        {
            e.Graphics.FillRectangle(brush, transform.position.X, transform.position.Y, transform.size.X, transform.size.Y);
        }

        public void Draw(PaintEventArgs e, Pen pen, Transform transform)
        {
            e.Graphics.DrawRectangle(pen, transform.position.X, transform.position.Y, transform.size.X, transform.size.Y);
        }
    }
}
