using System;
using System.Drawing;

namespace Client
{
    public class Player : GameObject
    {
        protected PlayerSpawner spawnPoint;
        protected Tank controllable;
        private TankBuilder builder;

        public Player() : this(null)
        {
        }

        public Player(PlayerSpawner spawnPoint)
        {
            this.spawnPoint = spawnPoint ?? new PlayerSpawner(50, 50);

            isShadowCaster = true;
            builder = new TankBuilder();
            TankDirector director = new TankDirector(builder);

            Transform tr = this.spawnPoint.transform;
            director.Construct(tr.position.X, tr.position.Y);
            Spawn();
        }

        public void Spawn()
        {
            controllable = builder.GetResult();
            controllable.transform.position = spawnPoint.transform.position;
            controllable.transform.rotation = spawnPoint.transform.rotation;
        }

        public void Despawn()
        {
            controllable.Destroy();
        }

        ~Player()
        {
            Despawn();
        }
    }
}
