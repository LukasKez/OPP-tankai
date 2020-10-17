﻿using System.Drawing;

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
            collider = obstacle.collider;
            isShadowCaster = obstacle.isShadowCaster;

            transform = obstacle.transform;

            shape = Shape.Ellipse;
            brush = Brushes.DarkGreen;
        }
    }
}
