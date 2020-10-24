using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Ellipse
    {
        public Ellipse()
        {
        }

        public void Draw(PaintEventArgs e, Brush brush, Transform transform)
        {
            e.Graphics.FillEllipse(brush, transform.position.X, transform.position.Y, transform.size.X, transform.size.Y);
        }

        public void Draw(PaintEventArgs e, Pen pen, Transform transform)
        {
            e.Graphics.DrawEllipse(pen, transform.position.X, transform.position.Y, transform.size.X, transform.size.Y);
        }
    }
}
