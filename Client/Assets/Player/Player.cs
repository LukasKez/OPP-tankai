using System;
using System.Drawing;

namespace Client
{
    public class Player : GameObject
    {
        protected PlayerSpawner spawnPoint;
        protected Tank controllable;
        public TankType tankType;
        private ITankBuilder builder;

        public Player() : this(null)
        {
        }

        public Player(PlayerSpawner spawnPoint)
        {
            this.spawnPoint = spawnPoint ?? new PlayerSpawner(GameState.Instance.mapSize.X / 2, GameState.Instance.mapSize.Y / 2);
            isShadowCaster = true;
        }

        public void Spawn()
        {
            switch (tankType)
            {
                case TankType.HeavyTank:
                    builder = new HeavyTankBuilder();
                    break;
                case TankType.LightTank:
                    builder = new LightTankBuilder();
                    break;
                default:
                    builder = new HeavyTankBuilder();
                    break;
            }
            TankDirector director = new TankDirector(builder);

            Transform tr = spawnPoint.transform;
            director.Construct(tr.position.X, tr.position.Y);

            controllable = builder.GetResult();
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
