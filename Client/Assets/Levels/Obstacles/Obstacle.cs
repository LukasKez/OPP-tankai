using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.Obstacles
{
    abstract class Obstacle : GameObject
    {

        public Obstacle(float x, float y, float width, float height)
            :base(x,y,width,height)
        {
        }
        public override void Render(PaintEventArgs e)
        {
            
        }
    }
}
