﻿using System.Drawing;

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
            base.Decorate();
            adapter.SetFields(this);

            MakeWall();
        }
        private void MakeWall()
        {
            shape = Shape.Rectangle;
            brush = Brushes.DarkGray;
        }


    }
}
