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
        [Obsolete()] public float speed = 50;    // TODO: Delete

        public Engine engine { get; set; }
        public Suspension suspension { get; set; }
        public Turret turret { get; set; }


        private List<TemporaryPowerUp> temporaryPowerUps;

        public Tank(Transform transform, Brush brush) : base(transform)
        {
            GenerateAABB(transform.size + new Vector2(6, 4));
            shape = Shape.Rectangle;
            collider = ColliderType.Collider;
            isShadowCaster = true;
            this.brush = brush;
            pen = new Pen(Color.FromArgb(64, Color.Black), 2);
            temporaryPowerUps = new List<TemporaryPowerUp>();
        }

        public override void Update(float deltaTime)
        {
            UpdatePowerUps(deltaTime);
        }

        public override void OnTrigger(Collision collision)
        {
            base.OnTrigger(collision);

            if (collision.other is PowerUpSpawner powerUpSpawner &&
               (collision.penetration * collision.normal).LengthSquared() > 32f)
            {
                PowerUp(powerUpSpawner.GiveAway());
            }
        }

        public void Move(float direction)
        {
            Vector2 vertical = new Vector2();
            vertical.Y = direction * speed * GameLoop.DeltaTime;
            transform.position += Utils.Rotate(vertical, transform.rotation);
        }

        public void Rotate(float direction)
        {
            transform.rotation += direction * speed * GameLoop.DeltaTime;
        }

        public void LookAt(float direction)
        {
            turret.Rotate(direction);
        }

        public void Action()
        {
            turret.gun.Shoot();
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
