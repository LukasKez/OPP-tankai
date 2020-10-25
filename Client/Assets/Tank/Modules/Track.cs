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
            this.brush = Brushes.DimGray;
            pen = new Pen(Color.FromArgb(64, Color.Black), 2);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //transform.position = parent.transform.position;
            //transform.rotation = parent.transform.rotation;
        }
    }
}
