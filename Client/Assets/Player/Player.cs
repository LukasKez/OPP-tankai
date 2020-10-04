using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Player : GameObject
    {
        protected Tank controllable = new Tank(0, 0);

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
