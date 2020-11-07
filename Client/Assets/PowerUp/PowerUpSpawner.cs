using Client;
using System;
using System.Drawing;
using System.Numerics;

namespace PowerUp
{
    class PowerUpSpawner : Spawner
    {
        private PowerUpBase powerUp;
        private float waitDuration = 5f;
        private float waitTime;

        public PowerUpSpawner(float x, float y, float w, float h, SpawnImplementor imp) : base(x, y, w, h, imp)
        {
            shape = Shape.Ellipse;
            collider = ColliderType.Trigger;
            outlinePen = new Pen(Brushes.Orange, 2);
            waitTime = waitDuration;
        }

        public override void Update(float deltaTime)
        {
            if (powerUp == null)
            {
                if (waitTime <= 0)
                {
                    Spawn(powerUp);
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

        public override void Spawn(GameObject gameObject)
        {
            Console.WriteLine("Extended abstract spawner Spawn() method");
            base.Spawn(gameObject);
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
