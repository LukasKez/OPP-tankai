﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    class LocalPlayer : Player
    {
        private float elapsedTime = 0f;
        private float updateRate = 1f / 40f;

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (GameState.focused)
                UpdatePosition(deltaTime);

            elapsedTime += deltaTime;
            if (elapsedTime > updateRate)
            {
                elapsedTime -= updateRate;
                Networking.SendPositionUpdateAsync(controllable);
            }
        }

        void UpdatePosition(float deltaTime)
        {
            Vector vertical = new Vector();
            float speed = controllable.speed;
            Transform tr = controllable.transform;

            if (Keyboard.IsKeyDown(Key.W))
            {
                vertical.Y = -speed * deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                tr.rotation -= speed * deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                vertical.Y = speed * deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                tr.rotation += speed * deltaTime;
            }

            double radians = tr.rotation * Math.PI / 180;
            tr.position.X += vertical.X * Math.Cos(radians) - vertical.Y * Math.Sin(radians);
            tr.position.Y += vertical.X * Math.Sin(radians) + vertical.Y * Math.Cos(radians);
            controllable.transform = tr;
        }
    }
}
