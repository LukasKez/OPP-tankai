

using System;

namespace Client
{
    class DamageObstacle : ObstacleDecorator
    {
        public DamageObstacle(GameObject decoredObject)
            : base(decoredObject)
        {
        }
        public override void Decorate()
        {
            obstacle.Decorate();
            collider = obstacle.collider;
            isShadowCaster = obstacle.isShadowCaster;
            damage = obstacle.damage;
            shape = obstacle.shape;
            brush = obstacle.brush;

            transform = obstacle.transform;
            MakeDamageObstacle();
        }

        private void MakeDamageObstacle()
        {
            damage = 10;
        }
    }
}
