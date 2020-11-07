using PowerUp;
using System.Drawing;

namespace Client
{
    class Field : GameLevel
    {
        public Field(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            stuff.Add(new Ground(new Transform(levelWidth / 2, levelHeight / 2, levelWidth, levelHeight), Brushes.LightGreen));

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

            // Add PowerUp spawners
            stuff.Add(new PowerUpSpawner(levelWidth / 2, levelHeight / 2, blockWidth, blockHeight));

            // Add Player spawners
            stuff.Add(new PlayerSpawner(blockWidth * 4, blockHeight * 4, 135));
            stuff.Add(new PlayerSpawner(levelWidth - blockWidth * 4, blockHeight * 4, -135));
            stuff.Add(new PlayerSpawner(blockWidth * 4, levelHeight - blockHeight * 4, 45));
            stuff.Add(new PlayerSpawner(levelWidth - blockWidth * 4, levelHeight - blockHeight * 4, -45));
        }

        public override void SetupObstacles(LevelType levelType)
        {
            GameObject obj;

            // Center obstacles
            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 - blockWidth * 3, levelHeight / 2 - blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 - blockWidth * 2, levelHeight / 2 - blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 - blockWidth * 3, levelHeight / 2 - blockHeight * 2, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 + blockWidth * 3, levelHeight / 2 - blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 + blockWidth * 2, levelHeight / 2 - blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 + blockWidth * 3, levelHeight / 2 - blockHeight * 2, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 - blockWidth * 3, levelHeight / 2 + blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 - blockWidth * 2, levelHeight / 2 + blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 - blockWidth * 3, levelHeight / 2 + blockHeight * 2, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 + blockWidth * 3, levelHeight / 2 + blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 + blockWidth * 2, levelHeight / 2 + blockHeight * 3, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(levelWidth / 2 + blockWidth * 3, levelHeight / 2 + blockHeight * 2, blockWidth, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            // Side obstacles
            obj = new OutlineObstacle(new Water(new Obstacle(levelWidth / 2, blockHeight / 2 + blockHeight * 3, blockWidth, blockHeight * 3)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Water(new Obstacle(levelWidth / 2, levelHeight - blockHeight / 2 - blockHeight * 3, blockWidth, blockHeight * 3)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Water(new Obstacle(blockWidth / 2 + blockWidth * 3, levelHeight / 2, blockWidth * 3, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Water(new Obstacle(levelWidth - blockWidth / 2 - blockWidth * 3, levelHeight / 2, blockWidth * 3, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            // Corner obstacles
            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 - blockWidth * 8, levelHeight / 2 - blockHeight * 9.5f, blockWidth, blockHeight * 2)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 - blockWidth * 9, levelHeight / 2 - blockHeight * 8, blockWidth * 3, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 + blockWidth * 8, levelHeight / 2 - blockHeight * 9.5f, blockWidth, blockHeight * 2)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 + blockWidth * 9, levelHeight / 2 - blockHeight * 8, blockWidth * 3, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 - blockWidth * 8, levelHeight / 2 + blockHeight * 9.5f, blockWidth, blockHeight * 2)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 - blockWidth * 9, levelHeight / 2 + blockHeight * 8, blockWidth * 3, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 + blockWidth * 8, levelHeight / 2 + blockHeight * 9.5f, blockWidth, blockHeight * 2)));
            obj.Decorate();
            stuff.Add(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(levelWidth / 2 + blockWidth * 9, levelHeight / 2 + blockHeight * 8, blockWidth * 3, blockHeight)));
            obj.Decorate();
            stuff.Add(obj);
        }
    }
}
