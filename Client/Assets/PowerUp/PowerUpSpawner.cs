using Client;
using System;
using System.Drawing;

namespace PowerUp
{
    class PowerUpSpawner : Spawner
    {
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
            if (spawnedObj == null)
            {
                if (waitTime <= 0)
                {
                    Spawn(spawnedObj);
                    waitTime = waitDuration;
                }
                else
                {
                    waitTime -= deltaTime;
                }
            }
            else
            {
                spawnedObj.Update(deltaTime);
            }
        }

        public override void Spawn(GameObject gameObject)
        {
            Console.WriteLine("Extended abstract spawner Spawn() method");
            base.Spawn(gameObject);
        }

        public PowerUpBase GiveAway()
        {
            if (spawnedObj == null) return null;

            PowerUpBase powerUpToGive = spawnedObj as PowerUpBase;
            spawnedObj.Destroy();
            spawnedObj = null;

            return powerUpToGive;
        }
    }
}
