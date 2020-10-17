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
            collider = obstacle.collider;
            isShadowCaster = obstacle.isShadowCaster;

            transform = obstacle.transform;
            
            shape = Shape.Rectangle;
            brush = Brushes.DarkGray;
        }


    }
}
