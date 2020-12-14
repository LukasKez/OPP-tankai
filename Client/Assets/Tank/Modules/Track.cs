using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class Track : GameObject
    {
        public Track(float x, float y, Vector2 size) : base(new TransformLeaf(x, y, size.X / 2, size.Y + 6))
        {
            shape = Shape.Rectangle;
            isShadowCaster = true;
            brush = Brushes.DimGray;
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 1);
        }
    }
}
