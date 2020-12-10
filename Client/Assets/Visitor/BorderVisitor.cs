
namespace Client
{
    class BorderVisitor : IVisitor
    {
        public void Visit(Field field)
        {
            // Horizontal borders

            GameObject gameObject = new Water(new Obstacle(field.levelWidth / 2, field.blockHeight / 2, field.levelWidth, field.blockHeight));
            gameObject.Decorate();
            field.AddStuff(gameObject);

            gameObject = new Water(new Obstacle(field.levelWidth / 2, field.levelHeight - field.blockHeight + field.blockHeight / 2, field.levelWidth, field.blockHeight));
            gameObject.Decorate();
            field.AddStuff(gameObject);

            // Vertical borders

            gameObject = new Water(new Obstacle(field.blockWidth / 2, field.levelHeight / 2, field.blockWidth, field.levelHeight));
            gameObject.Decorate();
            field.AddStuff(gameObject);

            gameObject = new Water(new Obstacle(field.levelWidth - field.blockWidth + field.blockWidth / 2, field.levelHeight / 2, field.blockWidth, field.levelHeight));
            gameObject.Decorate();
            field.AddStuff(gameObject);
        }

        public void Visit(Forest forest)
        {
            // Horizontal borders

            GameObject gameObject = new OutlineObstacle(new Water(new Obstacle(forest.levelWidth / 2, forest.blockHeight / 2, forest.levelWidth, forest.blockHeight)));
            gameObject.Decorate();
            forest.AddStuff(gameObject);

            gameObject = new OutlineObstacle(new Water(new Obstacle(forest.levelWidth / 2, forest.levelHeight - forest.blockHeight + forest.blockHeight / 2, forest.levelWidth, forest.blockHeight)));
            gameObject.Decorate();
            forest.AddStuff(gameObject);

            // Vertical borders

            gameObject = new OutlineObstacle(new Water(new Obstacle(forest.blockWidth / 2, forest.levelHeight / 2, forest.blockWidth, forest.levelHeight)));
            gameObject.Decorate();
            forest.AddStuff(gameObject);

            gameObject = new OutlineObstacle(new Water(new Obstacle(forest.levelWidth - forest.blockWidth + forest.blockWidth / 2, forest.levelHeight / 2, forest.blockWidth, forest.levelHeight)));
            gameObject.Decorate();
            forest.AddStuff(gameObject);
        }

        public void Visit(Cave cave)
        {
            for (float x = cave.blockWidth / 2; x < cave.levelWidth; x += cave.blockWidth)
            {
                GameObject gameObject = new OutlineObstacle(new Boulder(new Obstacle(x, cave.blockHeight / 2, cave.blockWidth, cave.blockHeight)));
                gameObject.Decorate();
                cave.AddStuff(gameObject);

                gameObject = new OutlineObstacle(new Boulder(new Obstacle(x, cave.levelHeight - cave.blockHeight / 2, cave.blockWidth, cave.blockHeight)));
                gameObject.Decorate();
                cave.AddStuff(gameObject);
            }

            for (float y = cave.blockHeight + cave.blockHeight / 2; y < cave.levelHeight - cave.blockHeight; y += cave.blockHeight)
            {
                GameObject gameObject = new OutlineObstacle(new Boulder(new Obstacle(cave.blockWidth / 2, y, cave.blockWidth, cave.blockHeight)));
                gameObject.Decorate();
                cave.AddStuff(gameObject);

                gameObject = new OutlineObstacle(new Boulder(new Obstacle(cave.levelWidth - cave.blockWidth / 2, y, cave.blockWidth, cave.blockHeight)));
                gameObject.Decorate();
                cave.AddStuff(gameObject);
            }
        }

        public void Visit(Desert desert)
        {
            // Horizontal borders

            GameObject gameObject = new OutlineObstacle(new Water(new Obstacle(desert.levelWidth / 2, desert.blockHeight / 2, desert.levelWidth, desert.blockHeight)));
            gameObject.Decorate();
            desert.AddStuff(gameObject);

            gameObject = new OutlineObstacle(new Water(new Obstacle(desert.levelWidth / 2, desert.levelHeight - desert.blockHeight + desert.blockHeight / 2, desert.levelWidth, desert.blockHeight)));
            gameObject.Decorate();
            desert.AddStuff(gameObject);

            // Vertical borders

            gameObject = new OutlineObstacle(new Water(new Obstacle(desert.blockWidth / 2, desert.levelHeight / 2, desert.blockWidth, desert.levelHeight)));
            gameObject.Decorate();
            desert.AddStuff(gameObject);

            gameObject = new OutlineObstacle(new Water(new Obstacle(desert.levelWidth - desert.blockWidth + desert.blockWidth / 2, desert.levelHeight / 2, desert.blockWidth, desert.levelHeight)));
            gameObject.Decorate();
            desert.AddStuff(gameObject);
        }
    }
}
