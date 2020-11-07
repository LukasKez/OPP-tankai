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
            base.Decorate();
            adapter.SetFields(this);
            GenerateAABB();

            MakeDamageObstacle();
        }

        private void MakeDamageObstacle()
        {
            damage = 10;
        }
    }
}
