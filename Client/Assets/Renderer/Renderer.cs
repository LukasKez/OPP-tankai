﻿using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Client
{
    class Renderer
    {
        private Rectangle rectangle = new Rectangle();
        private Ellipse ellipse;
        private Rotator rotator;

        public Renderer()
        {
            rectangle = new Rectangle();
            ellipse = new Ellipse();
            rotator = new Rotator();
        }

        public void RenderShape(PaintEventArgs e, Brush brush, Transform transform, Shape shape)
        {
            if (shape == Shape.None) return;

            if (transform.WorldRotation != 0)
            {
                rotator.Rotate(e, transform);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    rectangle.Draw(e, brush, transform.WorldPosition, transform.size);
                    break;
                case Shape.Ellipse:
                    ellipse.Draw(e, brush, transform.WorldPosition, transform.size);
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

        public void RenderShape(PaintEventArgs e, Pen pen, Transform transform, Shape shape)
        {
            if (shape == Shape.None) return;

            if (transform.WorldRotation != 0)
            {
                rotator.Rotate(e, transform);
            }

            switch (shape)
            {
                case Shape.Rectangle:
                    rectangle.Draw(e, pen, transform.WorldPosition, transform.size.Substract(pen.Width));
                    break;
                case Shape.Ellipse:
                    ellipse.Draw(e, pen, transform.WorldPosition, transform.size.Substract(pen.Width));
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
    }
}
