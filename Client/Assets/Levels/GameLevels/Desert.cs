using Client.Obstacles;
using System;
using System.Drawing;

namespace Client.Assets.Levels.GameLevels
{
    class Desert : GameLevel
    {
        public Desert(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            stuff.Add(new Ground(new Transform(0, 0, levelWidth, levelHeight), Brushes.LightYellow));

            // Horizontal borders
            stuff.Add(new Water(0, 0, levelWidth, blockHeight));
            stuff.Add(new Water(0, levelHeight - blockHeight, levelWidth, blockHeight));

            // Vertical borders
            stuff.Add(new Water(0, 0, blockWidth, levelHeight));
            stuff.Add(new Water(levelWidth - blockWidth, 0, blockWidth, levelHeight));
        }

    }
}
