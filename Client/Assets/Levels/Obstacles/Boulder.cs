using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.Obstacles
{
    class Boulder : Obstacle
    {
        public Boulder(float x, float y, float width, float height)
            : base(x, y, width, height)
        {

        }

        public override void Render(PaintEventArgs e)
        {

            Rectangle rectangle = new Rectangle((int)x, (int)y, (int)width, (int)height);

            SolidBrush shadowBrush = new SolidBrush(Color.DarkGray);
            e.Graphics.FillEllipse(shadowBrush, rectangle);


        }
    }
}
