using System.Drawing;

namespace Client
{
    class Boulder : ObstacleDecorator
    {

        public Boulder(GameObject decoredObject)
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
            MakeBoulder();
        }
        private void MakeBoulder()
        {
            shape = Shape.Ellipse;
            brush = Brushes.Gray;
        }



    }
}
