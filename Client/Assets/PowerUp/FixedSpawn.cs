using System;
using PowerUp;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class FixedSpawn : SpawnImplementor
    {
        int type = -1;
        private PowerUpBase powerUp;
        Random rnd = new Random();
        public GameObject Spawn(GameObject spawner)
        {
            AbstractPowerUpFactory powerUpFactory;
            type++;

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
                    type = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            int percent = rnd.Next(100);
            Vector2 size = spawner.transform.size * new Vector2(0.6f, 0.7f);

            if (percent < 50)
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

        public int getCurrentType()
        {
            return this.type;
        }
    }
}
