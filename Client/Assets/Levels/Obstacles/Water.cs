using System.Drawing;

namespace Client
{
    class Water : ObstacleDecorator
    {
        public Water(GameObject decoredObject)
            :base(decoredObject)
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
            MakeWater();
        }
        private void MakeWater()
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkSlateBlue;
        }
    }
}
