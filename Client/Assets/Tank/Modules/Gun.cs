using System;
using System.Drawing;

namespace Client
{
    public class Gun : GameObject
    {
        public float reloadTime;
        public float aimingRate;
        public float rotationAngle;

        public float spreadAngle;
        public float minSpreadAngle;
        public float maxSpreadAngle;

        private float waitTime;

        public Gun(float length) : base(new Transform(0, -length / 2, 6, length))
        {
            shape = Shape.Rectangle;
            isShadowCaster = true;
            brush = Brushes.Gray;
            pen = new Pen(Color.FromArgb(64, Color.Black), 1);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            float newSpreadAngle = spreadAngle - aimingRate * deltaTime;
            spreadAngle = Math.Max(newSpreadAngle, minSpreadAngle);

            if (waitTime > 0)
            {
                waitTime -= deltaTime;
            }
        }

        public void Shoot()
        {
            if (waitTime <= 0)
            {
                // TODO: instantiate projectile

                spreadAngle = maxSpreadAngle;
                waitTime = reloadTime;
            }
        }
    }
}
