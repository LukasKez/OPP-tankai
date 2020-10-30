using System.Windows.Forms;
using System.Numerics;
using System;

namespace Client
{
    class Rotator
    {
        public Rotator()
        {
        }

        public void Rotate(PaintEventArgs e, Vector2 position, float rotation)
        {
            // Set the rotation point
            e.Graphics.TranslateTransform(position.X, position.Y);
            // Rotate
            e.Graphics.RotateTransform((float)Math.Round(rotation));
            // Restore rotation point in the matrix
            e.Graphics.TranslateTransform(-position.X, -position.Y);
        }
    }
}
