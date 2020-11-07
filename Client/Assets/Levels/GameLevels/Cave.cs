using System.Drawing;

namespace Client
{
    class Cave : GameLevel
    {
        public Cave(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            stuff.Add(new Ground(new Transform(levelWidth / 2, levelHeight / 2, levelWidth, levelHeight), Brushes.LightGray));
            SetupBorders();
        }

        public void SetupBorders()
        {
            for (float x = blockWidth / 2; x < levelWidth; x += blockWidth)
            {
                GameObject gameObject = new OutlineObstacle(new Boulder(new Obstacle(x, blockHeight / 2, blockWidth, blockHeight)));
                gameObject.Decorate();
                stuff.Add(gameObject);

                gameObject = new OutlineObstacle(new Boulder(new Obstacle(x, levelHeight - blockHeight / 2, blockWidth, blockHeight)));
                gameObject.Decorate();
                stuff.Add(gameObject);
            }

            for (float y = blockHeight + blockHeight / 2; y < levelHeight - blockHeight; y += blockHeight)
            {
                GameObject gameObject = new OutlineObstacle(new Boulder(new Obstacle(blockWidth / 2, y, blockWidth, blockHeight)));
                gameObject.Decorate();
                stuff.Add(gameObject);

                gameObject = new OutlineObstacle(new Boulder(new Obstacle(levelWidth - blockWidth / 2, y, blockWidth, blockHeight)));
                gameObject.Decorate();
                stuff.Add(gameObject);
            }
        }

    }
}
