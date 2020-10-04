using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.Obstacles
{
    class Wall : Obstacle
    {
        public Wall(float x, float y, float width, float height)
            : base(x, y, width, height)
        {

        }

        public override void Render(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkSlateGray, x, y, width, height);
        }
    }
}
