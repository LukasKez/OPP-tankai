using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
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

        public Tank(float x, float y, Brush brush) : base(x, y, 20, 20)
        {
            shape = Shape.Rectangle;
            this.brush = brush;
            temporaryPowerUps = new List<TemporaryPowerUp>();
        }

        public override void Update(float deltaTime)
        {
            UpdatePowerUps(deltaTime);
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
