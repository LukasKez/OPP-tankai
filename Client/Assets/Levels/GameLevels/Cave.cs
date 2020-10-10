using Client.Obstacles;
using System;
using System.Drawing;

namespace Client.Assets.Levels.GameLevels
{
    class Cave : GameLevel
    {
        public Cave(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            stuff.Add(new Ground(new Transform(0, 0, levelWidth, levelHeight), Brushes.LightGray));
            SetupBorders();
        }

        public void SetupBorders()
        {
            int i = 0;
            int j = 0;

            int vertEnd = (int)(levelWidth / blockWidth);
            int hozEnd = (int)(levelHeight / blockHeight);

            while (i < vertEnd || j < hozEnd)
            {
                if (i < vertEnd)
                {
                    stuff.Add(new Water(i * blockWidth, 0, blockWidth, blockHeight));
                    stuff.Add(new Water(i * blockWidth, levelHeight - blockHeight, blockWidth, blockHeight));
                    i++;
                }
                if (j < hozEnd)
                {
                    stuff.Add(new Water(0, j * blockHeight, blockWidth, blockHeight));
                    stuff.Add(new Water(levelWidth - blockWidth, j * blockHeight, blockWidth, blockHeight));
                    j++;
                }
            }
        }

    }
}
