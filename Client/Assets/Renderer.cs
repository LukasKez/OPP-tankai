using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    static class Renderer
    {
        public static void Rectangle(PaintEventArgs e, Brush brush, Transform transform)
        {
            if (transform.rotation != 0)
            {
                Rotate(e, transform);
            }
            
            e.Graphics.FillRectangle(brush, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);

            if (transform.rotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        public static void Ellipse(PaintEventArgs e, Brush brush, Transform transform)
        {
            if (transform.rotation != 0)
            {
                Rotate(e, transform);
            }

            e.Graphics.FillEllipse(brush, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);

            if (transform.rotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        private static void Rotate(PaintEventArgs e, Transform transform)
        {
            // Set the rotation point
            e.Graphics.TranslateTransform((float)transform.position.X + (float)transform.size.X / 2, (float)transform.position.Y + (float)transform.size.Y / 2);
            // Rotate
            e.Graphics.RotateTransform(transform.rotation);
            // Restore rotation point in the matrix
            e.Graphics.TranslateTransform((float)-(transform.position.X + transform.size.X / 2), (float)-(transform.position.Y + transform.size.Y / 2));
        }
    }
}
