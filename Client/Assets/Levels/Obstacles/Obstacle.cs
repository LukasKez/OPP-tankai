using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.Obstacles
{
    abstract class Obstacle
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public float width { get; private set; }
        public float height { get; private set; }

        public Obstacle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public abstract void Render(PaintEventArgs e);
    }
}
