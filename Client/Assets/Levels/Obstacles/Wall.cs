using System.Drawing;

namespace Client
{
    class Wall : ObstacleDecorator
    {
        public Wall(GameObject decoredObject)
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
            MakeWall();
        }
        private void MakeWall()
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkGray;
        }


    }
}
