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
        private float oldTuretRot;
        private float newTuretRot;
        private float lerpAmount;

        private float updateRate = 0.1f;
        private StringFormat nameFormat;

        public string name;
        public bool isReady;

        public RemotePlayer()
        {
            oldPos = new Transform(spawnPoint.transform);
            newPos = new Transform(spawnPoint.transform);

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
            controllable.turret.transform.rotation = Utils.Lerp(oldTuretRot, newTuretRot, lerpAmount);
        }

        public override void Render(PaintEventArgs e)
        {
            base.Render(e);

            Transform tr = controllable.transform;
            float x = tr.position.X;
            float y = tr.position.Y - Control.DefaultFont.Height - 18;
            e.Graphics.DrawString(name, Control.DefaultFont, Brushes.Black, x, y, nameFormat);
        }

        public void SetPosition(float x, float y, float r1, float r2)
        {
            oldPos.position = newPos.position;
            oldPos.rotation = newPos.rotation;
            oldTuretRot = newTuretRot;
            lerpAmount = 0;

            newPos.position.X = x;
            newPos.position.Y = y;
            newPos.rotation = r1;
            newTuretRot = r2;
        }
    }
}
