using Client;
using System;
using System.Drawing;
using System.Numerics;

namespace PowerUp
{
    class PowerUpSpawner : GameObject
    {
        private PowerUpBase powerUp;
        private float waitDuration = 5f;
        private float waitTime;
        Random rnd;

        public PowerUpSpawner(float x, float y, float w, float h) : base(new Transform(x, y, w, h))
        {
            shape = Shape.Ellipse;
            collider = ColliderType.Trigger;
            pen = new Pen(Brushes.Orange, 2);
            waitTime = waitDuration;
            rnd = new Random(GameState.Instance.RandomSeed ^ (int)x ^ (int)y << 8);
            Console.WriteLine(GameState.Instance.RandomSeed ^ (int)x ^ (int)y << 8);
        }

        public override void Update(float deltaTime)
        {
            if (powerUp == null)
            {
                if (waitTime <= 0)
                {
                    Spawn();
                    waitTime = waitDuration;
                }
                else
                {
                    waitTime -= deltaTime;
                }
            }
            else
            {
                powerUp.Update(deltaTime);
            }
        }

        private void Spawn()
        {
            AbstractPowerUpFactory powerUpFactory;

            int type = rnd.Next(4);

            switch (type)
            {
                case 0:
                    powerUpFactory = new AttackFactory();
                    break;
                case 1:
                    powerUpFactory = new DefenseFactory();
                    break;
                case 2:
                    powerUpFactory = new HealthFactory();
                    break;
                case 3:
                    powerUpFactory = new SpeedFactory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            int percent = rnd.Next(100);
            Vector2 size = transform.size * new Vector2(0.7f, 0.8f);

            if (percent < 80)
            {
                powerUp = powerUpFactory.CreateTemporaryPowerUp(0, 0, size.X, size.Y);
            }
            else
            {
                powerUp = powerUpFactory.CreatePermanentPowerUp(0, 0, size.X, size.Y);
            }
            Instantiate(powerUp, this);
        }

        public PowerUpBase GiveAway()
        {
            if (powerUp == null) return null;

            PowerUpBase powerUpToGive = powerUp;
            powerUp.Destroy();
            powerUp = null;

            return powerUpToGive;
        }
    }
}
