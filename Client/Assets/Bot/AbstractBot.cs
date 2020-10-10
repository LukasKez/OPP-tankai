using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class AbstractBot : GameObject
    {
        protected Tank controllable = new Tank(50, 50, Brushes.Blue);

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
