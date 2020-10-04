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
            base.Render(e);
        }
    }
}
