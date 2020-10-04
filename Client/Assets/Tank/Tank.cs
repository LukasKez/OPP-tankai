using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using PowerUp;


namespace Client
{
    public class Tank : GameObject
    {
        public float attack = 1;
        public float defense = 100;
        public float health = 100;
        public float speed = 100;

        List<TemporaryPowerUp> temporaryPowerUps;

        public Tank(float x, float y, float w, float h) : base(x, y, w, h)
        {
            temporaryPowerUps = new List<TemporaryPowerUp>();
        }

        public override void Render(PaintEventArgs e)
        {
            // Set the rotation point
            e.Graphics.TranslateTransform((float)transform.position.X + (float)transform.size.X / 2, (float)transform.position.Y + (float)transform.size.Y / 2);
            // Rotate
            e.Graphics.RotateTransform(transform.rotation);
            // Restore rotation point in the matrix
            e.Graphics.TranslateTransform((float)-(transform.position.X + transform.size.X / 2), (float)-(transform.position.Y + transform.size.Y / 2));
            // Draw rectangle
            e.Graphics.FillRectangle(Brushes.Red, (float)transform.position.X, (float)transform.position.Y, (float)transform.size.X, (float)transform.size.Y);
            e.Graphics.ResetTransform();
        }

        public override void Update(float deltaTime)
        {
            UpdatePosition(deltaTime);
            UpdatePowerUps(deltaTime);
        }

        void UpdatePosition(float deltaTime)
        {
            Vector vertical = new Vector();

            if (Keyboard.IsKeyDown(Key.W))
            {
                vertical.Y = -speed * deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                transform.rotation -= speed * deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                vertical.Y = speed * deltaTime;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                transform.rotation += speed * deltaTime;
            }

            double radians = transform.rotation * Math.PI / 180;
            transform.position.X += vertical.X * Math.Cos(radians) - vertical.Y * Math.Sin(radians);
            transform.position.Y += vertical.X * Math.Sin(radians) + vertical.Y * Math.Cos(radians);
        }

        void UpdatePowerUps(float deltaTime)
        {
            foreach (var powerUp in temporaryPowerUps)
            {
                powerUp.duration -= deltaTime;
                if (powerUp.duration <= 0)
                {
                    powerUp.Unuse(this);
                    temporaryPowerUps.Remove(powerUp);
                }
            }
        }

        void PowerUp(PermanentPowerUp powerUp)
        {
            powerUp.Use(this);
        }

        void PowerUp(TemporaryPowerUp powerUp)
        {
            temporaryPowerUps.Add(powerUp);
            powerUp.Use(this);
        }
    }
}
