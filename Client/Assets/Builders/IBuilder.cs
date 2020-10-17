using Client.Obstacles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assets.Levels.Obstacles
{
    interface IBuilder
    {
        IBuilder SetSizeModifier(float modifier);
        IBuilder SetBrush(Brush brush);
        IBuilder SetShape(Shape shape);
        IBuilder MakeNewGameObject(float x, float y, float blockWidth, float blockHeight);
    }
}
