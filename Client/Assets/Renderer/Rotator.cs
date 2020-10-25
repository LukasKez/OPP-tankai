using System.Windows.Forms;
using System.Numerics;

namespace Client
{
    class Rotator
    {
        public Rotator()
        {
        }

        public void Rotate(PaintEventArgs e, Transform transform)
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
