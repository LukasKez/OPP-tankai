using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using PowerUp;

namespace Client
{
    public class Tank : GameObject, IControllable
    {
        [Obsolete()] public float attack = 1;     // TODO: Delete
        [Obsolete()] public float defense = 100;  // TODO: Delete
        [Obsolete()] public float health = 100;   // TODO: Delete
        [Obsolete()] public float speed = 100;    // TODO: Delete

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

        public void Move(float direction)
        {
            Vector2 vertical = new Vector2();
            Vector2 newPosition = transform.position;

            vertical.Y = direction * speed * GameLoop.DeltaTime;
            newPosition += Utils.Rotate(vertical, transform.rotation);

            Transform oldTransform = transform;
            transform.position = newPosition;

            GameObject collision = GameState.Instance.gameLevel.GetCollision(this);
            if (collision != null)
            {
                if (collision.collider == ColliderType.Collider)
                {
                    transform = oldTransform;
                }
                else
                {
                    if (collision is PowerUpSpawner powerUpSpawner)
                    {
                        PowerUp(powerUpSpawner.GiveAway());
                    }
                }
            }
        }

        public void Rotate(float direction)
        {
            transform.rotation += direction * speed * GameLoop.DeltaTime;
        }

        public void LookAt(float direction)
        {
            throw new NotImplementedException();
        }

        public void Action()
        {
            throw new NotImplementedException();
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
