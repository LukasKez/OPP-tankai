using System;
using System.Drawing;
using System.Numerics;
using PowerUp;

namespace Client
{
    abstract class Spawner : GameObject
    {
        protected SpawnImplementor imp;

        public Spawner(float x, float y, float w, float h, SpawnImplementor imp) : base(new Transform(x, y, w, h))
        {
            shape = Shape.Ellipse;
            collider = ColliderType.Trigger;
            outlinePen = new Pen(Brushes.Orange, 2);
            this.imp = imp;
        }

        public abstract override void Update(float deltaTime);

        public virtual void Spawn(GameObject gameObject)
        {
            imp.Spawn(this);
        }
    }
}
