﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Obstacles
{
    class Wall : Obstacle
    {
        public Wall(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }

        public override void Render(PaintEventArgs e)
        {
            Renderer.Rectangle(e, Brushes.DarkSlateGray, transform);
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
