using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Player : GameObject
    {
        protected Tank controllable = new Tank(20, 20, Brushes.Red);

        public override void Render(PaintEventArgs e)
        {
            controllable.Render(e);
        }

        public override void Update(float deltaTime)
        {
            controllable.Update(deltaTime);
        }
    }
}
