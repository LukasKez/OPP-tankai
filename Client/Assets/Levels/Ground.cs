using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Ground : GameObject
    {
        public Ground(Transform transform, Brush brush) : base(transform)
        {
            shape = Shape.Rectangle;
            isStatic = true;
            this.brush = brush;
        }
    }
}
