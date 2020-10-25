using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    class Renderer
    {
        private Rectangle rectangle;
        private Ellipse ellipse;
        private Rotator rotator;

        public Renderer()
        {
            rectangle = new Rectangle();
            ellipse = new Ellipse();
            rotator = new Rotator();
        }

        public void RenderShape(PaintEventArgs e, Brush brush, Transform transform, Shape shape, Vector2 offset = default)
        {
            if (shape == Shape.None) return;

            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            if (rotation != 0)
            {
                rotator.Rotate(e, position + offset, rotation);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    rectangle.Draw(e, brush, position + offset, transform.size);
                    break;
                case Shape.Ellipse:
                    ellipse.Draw(e, brush, position + offset, transform.size);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (rotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }

        public void RenderShape(PaintEventArgs e, Pen pen, Transform transform, Shape shape, Vector2 offset = default)
        {
            if (shape == Shape.None) return;

            Vector2 position = transform.WorldPosition;
            float rotation = transform.WorldRotation;

            if (rotation != 0)
            {
                rotator.Rotate(e, position + offset, rotation);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    rectangle.Draw(e, pen, position + offset, transform.size.Substract(pen.Width));
                    break;
                case Shape.Ellipse:
                    ellipse.Draw(e, pen, position + offset, transform.size.Substract(pen.Width));
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }

            if (rotation != 0)
            {
                e.Graphics.ResetTransform();
            }
        }
    }
}
