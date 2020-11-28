using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    static class Renderer
    {
        public static void RenderShape(Graphics g, Brush brush, Transform transform, Shape shape, Vector2 offset = default)
        {
            if (shape == Shape.None) return;

            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            if (rotation != 0)
            {
                Rotator.Rotate(g, position + offset, rotation);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle.Draw(g, brush, position + offset, transform.size);
                    break;
                case Shape.Ellipse:
                    Ellipse.Draw(g, brush, position + offset, transform.size);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (rotation != 0)
            {
                g.ResetTransform();
            }
        }

        public static void RenderShape(Graphics g, Pen pen, Transform transform, Shape shape, Vector2 offset = default)
        {
            if (shape == Shape.None) return;

            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            if (rotation != 0)
            {
                Rotator.Rotate(g, position + offset, rotation);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    Rectangle.Draw(g, pen, position + offset, transform.size.Substract(pen.Width));
                    break;
                case Shape.Ellipse:
                    Ellipse.Draw(g, pen, position + offset, transform.size.Substract(pen.Width));
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (rotation != 0)
            {
                g.ResetTransform();
            }
        }
    }
}
