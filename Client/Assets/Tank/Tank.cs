using System;
using System.Collections.Generic;
using System.Drawing;
using PowerUp;

namespace Client
{
    public class Tank : GameObject
    {
        public float attack = 1;     // TODO: Delete
        public float defense = 100;  // TODO: Delete
        public float health = 100;   // TODO: Delete
        public float speed = 100;    // TODO: Delete

        public Engine engine { get; set; }
        public Suspension suspension { get; set; }
        public Turret turret { get; set; }


        private List<TemporaryPowerUp> temporaryPowerUps;

        public Tank(float x, float y, Brush brush) : base(x, y, 20, 20)
        {
            shape = Shape.Rectangle;
            isShadowCaster = true;
            this.brush = brush;
            pen = new Pen(Color.FromArgb(64, Color.Black), 2);
            temporaryPowerUps = new List<TemporaryPowerUp>();
        }

        public override void Update(float deltaTime)
        {
            UpdatePowerUps(deltaTime);
        }

        void UpdatePowerUps(float deltaTime)
        {
            foreach (var powerUp in temporaryPowerUps.ToArray())
            {
                powerUp.duration -= deltaTime;
                if (powerUp.duration <= 0)
                {
                    powerUp.Unuse(this);
                    temporaryPowerUps.Remove(powerUp);
                }
            }
        }

        public void PowerUp(PowerUpBase powerUp)
        {
            PowerUp(powerUp as PermanentPowerUp);
            PowerUp(powerUp as TemporaryPowerUp);
        }

        public void PowerUp(PermanentPowerUp powerUp)
        {
            powerUp?.Use(this);
        }

        public void PowerUp(TemporaryPowerUp powerUp)
        {
            if (powerUp == null) return;
            temporaryPowerUps.Add(powerUp);
            powerUp.Use(this);
        }
    }
}
