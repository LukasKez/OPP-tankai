using System;
using System.Drawing;
using System.Numerics;
using PowerUp;

namespace Client
{
    class RandomSpawn : SpawnImplementor
    {
        private PowerUpBase powerUp;
        private readonly Random rnd = new Random();

        public GameObject Spawn(GameObject spawner)
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
            Vector2 size = spawner.transform.size * new Vector2(0.7f, 0.8f);

            if (percent < 80)
            {
                powerUp = powerUpFactory.CreateTemporaryPowerUp(0, 0, size.X, size.Y);
            }
            else
            {
                powerUp = powerUpFactory.CreatePermanentPowerUp(0, 0, size.X, size.Y);
            }
            GameObject.Instantiate(powerUp, spawner);
            return powerUp;
        }
    }
}
