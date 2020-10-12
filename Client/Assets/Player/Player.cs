using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Player : GameObject
    {
        protected Tank controllable = new Tank(20, 20, Brushes.Red);

        public Player()
        {
            Instantiate(controllable);
        }
    }
}
