using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Player : GameObject
    {
        protected Tank controllable;

        public Player()
        {
            controllable = new Tank(20, 20, Brushes.Red);
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
