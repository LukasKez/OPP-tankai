﻿using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Client
{
    static class Ellipse
    {
        public static void Draw(Graphics g, Brush brush, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            g.FillEllipse(brush, position.X, position.Y, size.X, size.Y);
        }

        public static void Draw(Graphics g, Pen pen, Vector2 position, Vector2 size)
        {
            Vector2 radius = size * 0.5f;
            position -= radius;
            g.DrawEllipse(pen, position.X, position.Y, size.X, size.Y);
        }
    }
}
