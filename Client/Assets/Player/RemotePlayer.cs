using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    public class RemotePlayer : Player
    {
        private Transform oldPos;
        private Transform newPos;
        private float lerpAmount;

        private float updateRate = 0.1f;
        private StringFormat nameFormat;

        public string name;
        public bool isReady;

        public RemotePlayer()
        {
            nameFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center
            };
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            lerpAmount = Math.Min(lerpAmount + (deltaTime / updateRate), 1f);
            controllable.transform.position = Vector2.Lerp(oldPos.position, newPos.position, lerpAmount);
            controllable.transform.rotation = Utils.Lerp(oldPos.rotation, newPos.rotation, lerpAmount);
        }

        public override void Render(PaintEventArgs e)
        {
            base.Render(e);

            Transform tr = controllable.transform;
            float x = tr.position.X + tr.size.X / 2f;
            float y = tr.position.Y - Control.DefaultFont.Height - 8;
            e.Graphics.DrawString(name, Control.DefaultFont, Brushes.Black, x, y, nameFormat);
        }

        public void SetPosition(float x, float y, float r)
        {
            oldPos = newPos;
            lerpAmount = 0;

            newPos.position.X = x;
            newPos.position.Y = y;
            newPos.rotation = r;
        }
    }
}
