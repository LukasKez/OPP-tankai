using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    class Track : GameObject
    {
        public Track(float x, float y, Vector2 size) : base(new Transform(x, y, size.X / 2, size.Y + 6))
        {
            shape = Shape.Rectangle;
            isShadowCaster = true;
            brush = Brushes.DimGray;
            pen = new Pen(Color.FromArgb(64, Color.Black), 1);
        }
    }
}
