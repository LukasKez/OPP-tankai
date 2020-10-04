using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.Obstacles
{
    class Water : Obstacle
    {
        public Water(float x, float y, float width, float height)
            : base(x, y, width, height)
        {

        }

        public override void Render(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkBlue, x, y, width, height);
        }
    }
}
