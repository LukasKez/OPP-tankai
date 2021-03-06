﻿using System.Drawing;

namespace Client
{
    public class OutlineObstacle: ObstacleDecorator
    {

        public OutlineObstacle(GameObject decoredObject)
            : base(decoredObject)
        {
        }

        public override void Decorate()
        {
            base.Decorate();
            adapter.SetFields(this);
            GenerateAABB();

            MakeOutline();
        }

        private void MakeOutline()
        {
            Color color = (brush as SolidBrush).Color;
            flyweight = FlyweightFactory.GetFlyweight(color.ToArgb()) as GameObjectFlyweight;
        }
    }
}
