using System;
using System.Drawing;

namespace Client
{
    public class Player : GameObject
    {
        protected Tank controllable;
        private TankBuilder builder;

        public Player()
        {
            isShadowCaster = true;
            builder = new TankBuilder();
            TankDirector director = new TankDirector(builder);

            director.Construct(50, 50);
            Spawn();
        }

        public void Spawn()
        {
            controllable = builder.GetResult();
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
