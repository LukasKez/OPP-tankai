using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class Projectile : GameObject, ICloneable
    {
        public float speed;
        public int bounceCount;
        public float bounceAngle;

        public Projectile() : this(new Transform())
        {
        }

        public Projectile(Transform transform) : base(new Transform(transform.position.X, transform.position.Y, 8, 8, transform.rotation))
        {
            shape = Shape.Ellipse;
            collider = ColliderType.Collider;
            isShadowCaster = true;
            brush = Brushes.Goldenrod;
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 2);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override void OnCollision(Collision collision)
        {
            base.OnCollision(collision);

            if (bounceCount > 0)
            {
                bounceCount--;

                if (!Bounce(collision.normal, bounceAngle))
                {
                    Destroy();
                }

                return;
            }

            Destroy();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            Vector2 vertical = new Vector2();
            vertical.Y = -speed * deltaTime;
            transform.position += Utils.Rotate(vertical, transform.rotation);
        }

        public void SetPosition(Transform tr)
        {
            Vector2 oldSize = transform.size;
            transform = tr;
            transform.size = oldSize;
        }

        private bool Bounce(Vector2 normal, float minBounceAngle = 180)
        {
            Vector2 rotation = Utils.RotatedVector(transform.rotation + 90);
            Vector2 reflection = rotation.Reflect(normal);
            float angle = rotation.SignedAngle(reflection);

            if (angle <= minBounceAngle && angle >= -minBounceAngle)
            {
                transform.rotation += angle;
                return true;
            }

            return false;
        }
    }
}
