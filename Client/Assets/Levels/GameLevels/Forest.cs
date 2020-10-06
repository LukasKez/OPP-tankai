using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Assets.Levels.GameLevels
{
    class Forest : GameLevel
    {

        public Forest(float levelWidth,float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            
        }
        public override void Render(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGreen, 0, 0, levelWidth, levelHeight);
            base.Render(e);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }
    }
}
