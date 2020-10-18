using System.Drawing;

namespace Client
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
                    GameObject gameObject = new Boulder(new Obstacle(i * blockWidth, 0, blockWidth, blockHeight));
                    gameObject.Decorate();
                    stuff.Add(gameObject);

                    gameObject = new Boulder(new Obstacle(i * blockWidth, levelHeight - blockHeight, blockWidth, blockHeight));
                    gameObject.Decorate();
                    stuff.Add(gameObject);

                    i++;
                }
                if (j < hozEnd)
                {

                    GameObject gameObject = new Boulder(new Obstacle(0, j * blockHeight, blockWidth, blockHeight));
                    gameObject.Decorate();
                    stuff.Add(gameObject);

                    gameObject = new Boulder(new Obstacle(levelWidth - blockWidth, j * blockHeight, blockWidth, blockHeight));
                    gameObject.Decorate();
                    stuff.Add(gameObject);

                    j++;
                }
            }
        }

    }
}
