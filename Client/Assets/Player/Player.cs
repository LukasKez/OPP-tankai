﻿using System;
using System.Drawing;

namespace Client
{
    public class Player : GameObject
    {
        protected Tank controllable;

        public Player()
        {
            TankBuilder builder = new TankBuilder();
            TankDirector director = new TankDirector(builder);

            director.Construct(50, 50);
            controllable = builder.GetResult();

            Spawn();
        }

        public void Spawn()
        {
            Instantiate(controllable);
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
