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
            e.Graphics.FillRectangle(Brushes.DarkSlateGray, (int)transform.position.X, (int)transform.position.Y,
                (int)transform.size.X, (int)transform.size.Y);
        }

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
    }
}
