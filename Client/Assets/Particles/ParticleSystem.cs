using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class ParticleSystem : GameObject
    {
        struct Particle
        {
            RectangleF rect;
            Vector2 velocity;
            float lifeTime;
        }

        public Brush particleBrush;
        public float lifeTime;

        private RectangleF[] rects;
        private Particle[] particles;
        private Random rnd;

        private float timeLeft;

        public ParticleSystem(Vector2 position, float rotation, int maxParticles)
            : base(new Transform(position.X, position.Y, r: rotation))
        {
            rects = new RectangleF[maxParticles];
            particles = new Particle[maxParticles];

            rnd = new Random();
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i] = new RectangleF(-1, -1, 5, 5);
            }
        }

        public void Emit(int count)
        {
            Vector2 worldPosition = transform.WorldPosition;

            for (int i = 0; i < rects.Length; i++)
            {
                float x = worldPosition.X + rnd.Next(-10, 7);
                float y = worldPosition.Y + rnd.Next(-10, 7);

                rects[i] = new RectangleF(x, y, 4, 4);
            }

            timeLeft = lifeTime;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (timeLeft > 0)
            {
                timeLeft -= deltaTime;
            }
        }

        public override void Render(Graphics g)
        {
            if (timeLeft <= 0)
                return;

            g.FillRectangles(particleBrush, rects);
        }
    }
}
