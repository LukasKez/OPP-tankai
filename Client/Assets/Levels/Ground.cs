using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Ground : GameObject
    {
        private Brush brush;

        public Ground(Transform transform, Brush brush) : base(transform)
        {
            this.brush = brush;
        }

        public override void Render(PaintEventArgs e)
        {
            Renderer.Rectangle(e, brush, transform);
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
