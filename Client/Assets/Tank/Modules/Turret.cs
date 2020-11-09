using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class Turret : GameObject
    {
        public float rotationSpeed;
        public float hitPoints;
        public float reactionTime;

        private float waitTime;

        public Gun gun { get; set; }

        public Turret(Vector2 size) : base(new Transform(0, 0, size.X, size.Y))
        {
            shape = Shape.Ellipse;
            isShadowCaster = true;
            brush = Brushes.Gray;
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 2.5f);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (waitTime > 0)
            {
                waitTime -= deltaTime;
            }
        }

        public void Rotate(float direction)
        {
            if (direction == 0)
            {
                waitTime = reactionTime;
                return;
            }

            if (waitTime <= 0)
            {
                transform.rotation += direction * rotationSpeed * GameLoop.DeltaTime;
            }
        }
    }
}
