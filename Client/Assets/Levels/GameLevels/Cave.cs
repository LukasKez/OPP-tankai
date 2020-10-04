using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.GameLevels
{
    class Cave : GameLevel
    {
        public Cave(float levelWidth, float levelHeight, float blockWidth, float blockHeight) 
            : base(levelWidth, levelHeight, blockWidth, blockHeight)
        {

        }
        public override void Render(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, 0, 0, levelWidth, levelHeight);

            int i = 0;
            int j = 0;

            while (i < horizontalBorders.Length / 2 || j < verticalBorders.Length / 2)
            {
                if (i < horizontalBorders.Length / 2)
                {
                    horizontalBorders[i, 0].Render(e);
                    horizontalBorders[i, 1].Render(e);
                    i++;
                }
                if (j < verticalBorders.Length / 2)
                {
                    verticalBorders[j, 0].Render(e);
                    verticalBorders[j, 1].Render(e);
                    j++;
                }
            }
        }
    }
}
