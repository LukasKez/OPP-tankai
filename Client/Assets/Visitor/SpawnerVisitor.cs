
using PowerUp;

namespace Client
{
    class SpawnerVisitor : IVisitor
    {
        public void Visit(Field field)
        {
            // Add PowerUp spawners
            field.AddStuff(new PowerUpSpawner(field.levelWidth / 2, field.levelHeight / 2, field.blockWidth, field.blockHeight, new FixedSpawn()));

            // Add Player spawners
            field.AddStuff(new PlayerSpawner(field.blockWidth * 4, field.blockHeight * 4, 135));
            field.AddStuff(new PlayerSpawner(field.levelWidth - field.blockWidth * 4, field.blockHeight * 4, -135));
            field.AddStuff(new PlayerSpawner(field.blockWidth * 4, field.levelHeight - field.blockHeight * 4, 45));
            field.AddStuff(new PlayerSpawner(field.levelWidth - field.blockWidth * 4, field.levelHeight - field.blockHeight * 4, -45));
        }

        public void Visit(Forest forest)
        {
            // Add PowerUp spawners
            forest.Add(new PowerUpSpawner(forest.blockWidth * 7, forest.blockHeight * 4, forest.blockWidth, forest.blockWidth, new RandomSpawn()));

            // Add Player spawners
            forest.AddStuff(new PlayerSpawner(forest.blockWidth * 4, forest.blockHeight * 4, 135));
            forest.AddStuff(new PlayerSpawner(forest.levelWidth - forest.blockWidth * 4, forest.blockHeight * 4, -135));
            forest.AddStuff(new PlayerSpawner(forest.blockWidth * 4, forest.levelHeight - forest.blockHeight * 4, 45));
            forest.AddStuff(new PlayerSpawner(forest.levelWidth - forest.blockWidth * 4, forest.levelHeight - forest.blockHeight * 4, -45));
        }

        public void Visit(Cave cave)
        {
            // Add PowerUp spawners
            cave.AddStuff(new PowerUpSpawner(cave.levelWidth / 2, cave.levelHeight / 2, cave.blockWidth, cave.blockHeight, new FixedSpawn()));

            // Add Player spawners
            cave.AddStuff(new PlayerSpawner(cave.blockWidth * 4, cave.blockHeight * 4, 135));
            cave.AddStuff(new PlayerSpawner(cave.levelWidth - cave.blockWidth * 4, cave.blockHeight * 4, -135));
            cave.AddStuff(new PlayerSpawner(cave.blockWidth * 4, cave.levelHeight - cave.blockHeight * 4, 45));
            cave.AddStuff(new PlayerSpawner(cave.levelWidth - cave.blockWidth * 4, cave.levelHeight - cave.blockHeight * 4, -45));
        }

        public void Visit(Desert desert)
        {
            // Add PowerUp spawners
            desert.AddStuff(new PowerUpSpawner(desert.levelWidth / 2, desert.levelHeight *0.25f, desert.blockWidth, desert.blockHeight, new FixedSpawn()));
            desert.AddStuff(new PowerUpSpawner(desert.levelWidth / 2, desert.levelHeight * 0.75f, desert.blockWidth, desert.blockHeight, new FixedSpawn()));

            // Add Player spawners
            desert.AddStuff(new PlayerSpawner(desert.blockWidth * 4, desert.blockHeight * 4, 135));
            desert.AddStuff(new PlayerSpawner(desert.levelWidth - desert.blockWidth * 4, desert.blockHeight * 4, -135));
            desert.AddStuff(new PlayerSpawner(desert.blockWidth * 4, desert.levelHeight - desert.blockHeight * 4, 45));
            desert.AddStuff(new PlayerSpawner(desert.levelWidth - desert.blockWidth * 4, desert.levelHeight - desert.blockHeight * 4, -45));

        }
    }
}
