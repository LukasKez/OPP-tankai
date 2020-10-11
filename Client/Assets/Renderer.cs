using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    static class Renderer
    {
        public static void RenderShape(PaintEventArgs e, Brush brush, Transform transform, Shape shape)
        {
            if (shape == Shape.None) return;

            if (transform.rotation != 0)
            {
                Rotate(e, transform);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle(e, brush, transform);
                    break;
                case Shape.Ellipse:
                    Ellipse(e, brush, transform);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (transform.rotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        public static void RenderShape(PaintEventArgs e, Pen pen, Transform transform, Shape shape)
        {
            if (shape == Shape.None) return;

            if (transform.rotation != 0)
            {
                Rotate(e, transform);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle(e, pen, transform);
                    break;
                case Shape.Ellipse:
                    Ellipse(e, pen, transform);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (transform.rotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        private static void Rectangle(PaintEventArgs e, Brush brush, Transform transform)
        {
            e.Graphics.FillRectangle(brush, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);
        }

        private static void Rectangle(PaintEventArgs e, Pen pen, Transform transform)
        {
            e.Graphics.DrawRectangle(pen, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);
        }

        private static void Ellipse(PaintEventArgs e, Brush brush, Transform transform)
        {
            e.Graphics.FillEllipse(brush, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);
        }

        private static void Ellipse(PaintEventArgs e, Pen pen, Transform transform)
        {
            e.Graphics.DrawEllipse(pen, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);
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
