using System.Numerics;
using System;
using System.Drawing;

namespace Client
{
    static class Rotator
    {
        public static void Rotate(Graphics g, Vector2 position, float rotation)
        {
            // Set the rotation point
            g.TranslateTransform(position.X, position.Y);
            // Rotate
            g.RotateTransform((float)Math.Round(rotation));
            // Restore rotation point in the matrix
            g.TranslateTransform(-position.X, -position.Y);
        }
    }
}
