using System.Drawing;

namespace Client
{
    class Tree : ObstacleDecorator
    {
        public Tree(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            obstacle.Decorate();
            collider = obstacle.collider;
            isStatic = obstacle.isStatic;
            isShadowCaster = obstacle.isShadowCaster;
            damage = obstacle.damage;
            shape = obstacle.shape;
            brush = obstacle.brush;

            transform = obstacle.transform;
            GenerateAABB();
            MakeTree();
        }
        private void MakeTree()
        {
            shape = Shape.Ellipse;
            brush = Brushes.DarkGreen;
        }
    }
}
