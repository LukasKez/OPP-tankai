using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    static class Renderer
    {
        public static void RenderShape(PaintEventArgs e, Brush brush, Transform transform, Shape shape)
        {
            if (shape == Shape.None) return;

            if (transform.WorldRotation != 0)
            {
                Rotate(e, transform);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle(e, brush, transform.WorldPosition, transform.size);
                    break;
                case Shape.Ellipse:
                    Ellipse(e, brush, transform.WorldPosition, transform.size);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (transform.WorldRotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        public static void RenderShape(PaintEventArgs e, Pen pen, Transform transform, Shape shape)
        {
            if (shape == Shape.None) return;

            if (transform.WorldRotation != 0)
            {
                Rotate(e, transform);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle(e, pen, transform.WorldPosition, transform.size.Substract(pen.Width));
                    break;
                case Shape.Ellipse:
                    Ellipse(e, pen, transform.WorldPosition, transform.size.Substract(pen.Width));
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (transform.WorldRotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        private static void Rectangle(PaintEventArgs e, Brush brush, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.FillRectangle(brush, position.X, position.Y, size.X, size.Y);
        }

        private static void Rectangle(PaintEventArgs e, Pen pen, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.DrawRectangle(pen, position.X, position.Y, size.X, size.Y);
        }

        private static void Ellipse(PaintEventArgs e, Brush brush, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.FillEllipse(brush, position.X, position.Y, size.X, size.Y);
        }

        private static void Ellipse(PaintEventArgs e, Pen pen, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            e.Graphics.DrawEllipse(pen, position.X, position.Y, size.X, size.Y);
        }

        private static void Rotate(PaintEventArgs e, Transform transform)
        {
            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            // Set the rotation point
            e.Graphics.TranslateTransform(position.X, position.Y);
            // Rotate
            e.Graphics.RotateTransform(rotation);
            // Restore rotation point in the matrix
            e.Graphics.TranslateTransform(-position.X, -position.Y);
        }
    }
}
