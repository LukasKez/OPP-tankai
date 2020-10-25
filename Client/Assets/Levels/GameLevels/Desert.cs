using System.Drawing;

namespace Client
{
    class Desert : GameLevel
    {
        public Desert(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            stuff.Add(new Ground(new Transform(levelWidth / 2, levelHeight / 2, levelWidth, levelHeight), Brushes.LightYellow));

            // Horizontal borders

            GameObject gameObject = new Water(new Obstacle(levelWidth / 2, blockHeight / 2, levelWidth, blockHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);

            gameObject = new Water(new Obstacle(levelWidth / 2, levelHeight - blockHeight + blockHeight / 2, levelWidth, blockHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);

            // Vertical borders

            gameObject = new Water(new Obstacle(blockWidth / 2, levelHeight / 2, blockWidth, levelHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);

            gameObject = new Water(new Obstacle(levelWidth - blockWidth + blockWidth / 2, levelHeight / 2, blockWidth, levelHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);
        }

    }
}
