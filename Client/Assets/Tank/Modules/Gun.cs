using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class Gun : GameObject
    {
        public Projectile shell;

        public float reloadTime;
        public float aimingRate;
        public float rotationAngle;

        public float spreadAngle;
        public float minSpreadAngle;
        public float maxSpreadAngle;

        private float waitTime;
        private Random rnd;

        public Gun(float length) : base(new Transform(0, -length / 2, 6, length))
        {
            shape = Shape.Rectangle;
            isShadowCaster = true;
            brush = Brushes.Gray;
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 1);

            rnd = new Random();
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
                Projectile projectile = (Projectile)shell.Clone();
                Transform tr = new Transform();

                tr.position = transform.WorldPosition;
                tr.rotation = transform.WorldRotation;
                tr.position += Utils.RotatedVector(tr.rotation + 90, -transform.size.Y);
                tr.rotation += Utils.Clamp((float)rnd.NextGaussian(0, spreadAngle / 1.6f), -spreadAngle, spreadAngle);
                projectile.SetPosition(tr);

                Networking.CreateProjectile(projectile);
                Instantiate(projectile);

                spreadAngle = maxSpreadAngle;
                waitTime = reloadTime;
            }
        }
    }
}
