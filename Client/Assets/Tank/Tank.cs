using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Client
{
    class Tank : GameObject
    {
        float speed = 2f;

        public Tank(float x, float y, float w, float h) : base(x, y, w, h)
        {
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
        }

        public override void Update(float deltaTime)
        {
            UpdatePosition(deltaTime);
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


    }
}
