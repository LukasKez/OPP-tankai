using System.Drawing;

namespace Client
{
    class GroundVisitor : IVisitor
    {
        public void Visit(Field field)
        {
            field.AddStuff(new Ground(new Transform(field.levelWidth / 2, field.levelHeight / 2, field.levelWidth, field.levelHeight), Brushes.LightGreen));
        }

        public void Visit(Forest forest)
        {
            forest.AddStuff(new Ground(new Transform(forest.levelWidth / 2, forest.levelHeight / 2, forest.levelWidth, forest.levelHeight), Brushes.LightGreen));
        }

        public void Visit(Cave cave)
        {
            cave.AddStuff(new Ground(new Transform(cave.levelWidth / 2, cave.levelHeight / 2, cave.levelWidth, cave.levelHeight), Brushes.LightGray));
        }

        public void Visit(Desert desert)
        {
            desert.AddStuff(new Ground(new Transform(desert.levelWidth / 2, desert.levelHeight / 2, desert.levelWidth, desert.levelHeight), Brushes.LightYellow));
        }
    }
}
