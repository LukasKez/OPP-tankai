
namespace Client
{
    class ObstacleVisitor : IVisitor
    {
        public void Visit(Field field)
        {
            GameObject obj;

            // Center obstacles
            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 - field.blockWidth * 3, field.levelHeight / 2 - field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 - field.blockWidth * 2, field.levelHeight / 2 - field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 - field.blockWidth * 3, field.levelHeight / 2 - field.blockHeight * 2, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 + field.blockWidth * 3, field.levelHeight / 2 - field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 + field.blockWidth * 2, field.levelHeight / 2 - field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 + field.blockWidth * 3, field.levelHeight / 2 - field.blockHeight * 2, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 - field.blockWidth * 3, field.levelHeight / 2 + field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 - field.blockWidth * 2, field.levelHeight / 2 + field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 - field.blockWidth * 3, field.levelHeight / 2 + field.blockHeight * 2, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 + field.blockWidth * 3, field.levelHeight / 2 + field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 + field.blockWidth * 2, field.levelHeight / 2 + field.blockHeight * 3, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(field.levelWidth / 2 + field.blockWidth * 3, field.levelHeight / 2 + field.blockHeight * 2, field.blockWidth, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            // Side obstacles
            obj = new OutlineObstacle(new Water(new Obstacle(field.levelWidth / 2, field.blockHeight / 2 + field.blockHeight * 3, field.blockWidth, field.blockHeight * 3)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Water(new Obstacle(field.levelWidth / 2, field.levelHeight - field.blockHeight / 2 - field.blockHeight * 3, field.blockWidth, field.blockHeight * 3)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Water(new Obstacle(field.blockWidth / 2 + field.blockWidth * 3, field.levelHeight / 2, field.blockWidth * 3, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Water(new Obstacle(field.levelWidth - field.blockWidth / 2 - field.blockWidth * 3, field.levelHeight / 2, field.blockWidth * 3, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            // Corner obstacles
            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 - field.blockWidth * 8, field.levelHeight / 2 - field.blockHeight * 9.5f, field.blockWidth, field.blockHeight * 2)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 - field.blockWidth * 9, field.levelHeight / 2 - field.blockHeight * 8, field.blockWidth * 3, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 + field.blockWidth * 8, field.levelHeight / 2 - field.blockHeight * 9.5f, field.blockWidth, field.blockHeight * 2)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 + field.blockWidth * 9, field.levelHeight / 2 - field.blockHeight * 8, field.blockWidth * 3, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 - field.blockWidth * 8, field.levelHeight / 2 + field.blockHeight * 9.5f, field.blockWidth, field.blockHeight * 2)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 - field.blockWidth * 9, field.levelHeight / 2 + field.blockHeight * 8, field.blockWidth * 3, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 + field.blockWidth * 8, field.levelHeight / 2 + field.blockHeight * 9.5f, field.blockWidth, field.blockHeight * 2)));
            obj.Decorate();
            field.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(field.levelWidth / 2 + field.blockWidth * 9, field.levelHeight / 2 + field.blockHeight * 8, field.blockWidth * 3, field.blockHeight)));
            obj.Decorate();
            field.AddStuff(obj);
        }

        public void Visit(Forest forest)
        {
            GameObject obj;
            for ( float vertical = forest.blockHeight*2f; vertical <= (forest.levelHeight-forest.blockHeight*1.5f); vertical += forest.blockHeight*5f)
            {
                for (float horizontal = forest.blockWidth * 2f; horizontal <= (forest.levelWidth - forest.blockWidth * 1f); horizontal += forest.blockWidth * 5f)
                {
                    obj = new OutlineObstacle(new Tree(new Obstacle(horizontal, vertical, forest.blockWidth, forest.blockHeight)));
                    obj.Decorate();
                    forest.AddStuff(obj);

                }
            }
        }

        public void Visit(Cave cave)
        {
            
        }

        public void Visit(Desert desert)
        {
            GameObject obj;

            // Center obstacles
            obj = new OutlineObstacle(new Water(new Obstacle(desert.levelWidth / 2 , desert.levelHeight / 2, desert.blockWidth*4, desert.blockHeight*4)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(desert.levelWidth / 2 - desert.blockWidth*2.5f, desert.levelHeight / 2-desert.blockWidth*2.5f, desert.blockWidth , desert.blockHeight )));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(desert.levelWidth / 2 + desert.blockWidth * 2.5f, desert.levelHeight / 2 - desert.blockWidth * 2.5f, desert.blockWidth, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(desert.levelWidth / 2 - desert.blockWidth * 2.5f, desert.levelHeight / 2 + desert.blockWidth * 2.5f, desert.blockWidth, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Tree(new Obstacle(desert.levelWidth / 2 + desert.blockWidth * 2.5f, desert.levelHeight / 2 + desert.blockWidth * 2.5f, desert.blockWidth, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);


            // Side obstacles
            obj = new OutlineObstacle(new Wall(new Obstacle(desert.blockWidth*5, desert.levelHeight *0.25f, desert.blockWidth * 8, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(desert.blockWidth * 5, desert.levelHeight * 0.75f, desert.blockWidth * 8, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(desert.levelWidth-desert.blockWidth * 5, desert.levelHeight * 0.25f, desert.blockWidth * 8, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Wall(new Obstacle(desert.levelWidth-desert.blockWidth * 5, desert.levelHeight * 0.75f, desert.blockWidth * 8, desert.blockHeight)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Boulder(new Obstacle(desert.levelWidth*0.5f, desert.blockHeight * 4, desert.blockWidth * 1.5f, desert.blockHeight* 1.5f)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Boulder(new Obstacle(desert.levelWidth * 0.5f, desert.blockHeight * 2, desert.blockWidth * 1.5f, desert.blockHeight * 1.5f)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Boulder(new Obstacle(desert.levelWidth * 0.5f, desert.levelHeight-desert.blockHeight * 4, desert.blockWidth * 1.5f, desert.blockHeight * 1.5f)));
            obj.Decorate();
            desert.AddStuff(obj);

            obj = new OutlineObstacle(new Boulder(new Obstacle(desert.levelWidth * 0.5f, desert.levelHeight - desert.blockHeight * 2, desert.blockWidth * 1.5f, desert.blockHeight * 1.5f)));
            obj.Decorate();
            desert.AddStuff(obj);
        }
    }
}
