using System.Windows.Forms;

namespace Client
{
    class Rotator
    {
        public Rotator()
        {
        }

        public void Rotate(PaintEventArgs e, Transform transform)
        {
            // Set the rotation point
            e.Graphics.TranslateTransform(transform.position.X + transform.size.X / 2, transform.position.Y + transform.size.Y / 2);
            // Rotate
            e.Graphics.RotateTransform(transform.rotation);
            // Restore rotation point in the matrix
            e.Graphics.TranslateTransform(-(transform.position.X + transform.size.X / 2), -(transform.position.Y + transform.size.Y / 2));
        }
    }
}
