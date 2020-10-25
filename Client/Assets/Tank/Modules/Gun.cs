using System;
using System.Drawing;

namespace Client
{
    public class Gun : GameObject
    {
        public float reloadTime;
        public float aimingTime;
        public float rotationAngle;

        public float spreadAngle;
        public float minSpreadAngle;
        public float maxSpreadAngle;

        public Gun(float length) : base(new Transform(0, -length / 2, 6, length))
        {
            shape = Shape.Rectangle;
            isShadowCaster = true;
            brush = Brushes.Gray;
            pen = new Pen(Color.FromArgb(64, Color.Black), 1);
        }
    }
}
