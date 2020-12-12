using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using PowerUp;

namespace Client
{
    public enum TankType
    {
        HeavyTank,
        LightTank,
    }

    public class Tank : GameObject, IControllable, ICloneable
    {
        [Obsolete()] public float attack = 1;     // TODO: Delete
        [Obsolete()] public float defense = 5;  // TODO: Delete
        [Obsolete()] public float health = 100;   // TODO: Delete
        [Obsolete()] public float speed = 50;    // TODO: Delete

        private int id;

        public Engine Engine { get; set; }
        public Suspension Suspension { get; set; }
        public Turret Turret { get; set; }


        public event Action<Projectile> OnProjectileHit;

        private List<TemporaryPowerUp> temporaryPowerUps;

        public Tank(Transform transform, Brush brush) : base(transform)
        {
            GenerateAABB(transform.size + new Vector2(6, 4));
            shape = Shape.Rectangle;
            collider = ColliderType.Collider;
            isShadowCaster = true;
            this.brush = brush;
            outlinePen = new Pen(Color.FromArgb(64, Color.Black), 2);
            temporaryPowerUps = new List<TemporaryPowerUp>();
        }

        public override void Update(float deltaTime)
        {
            UpdatePowerUps(deltaTime);
        }

        public override void OnCollision(Collision collision)
        {
            base.OnCollision(collision);

            if (collision.other is Projectile projectile)
            {
                ProjectileHit(projectile);
            }
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
            Turret.gun.Aim(-3f);
        }

        public void Rotate(float direction)
        {
            transform.rotation += direction * speed * GameLoop.DeltaTime;
            Turret.gun.Aim(-2.5f);
        }

        public void LookAt(float direction)
        {
            Turret.Rotate(direction);
            Turret.gun.Aim(-0.25f * Math.Abs(direction));
        }

        public void Action()
        {
            Turret.gun.Shoot();
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

        public void TakeDamage(float damage)
        {
            health -= Utils.Clamp(damage - defense, 0, health);

            if (health <= 0)
                GameState.Instance.State = ClientState.Died;
        }

        public void ProjectileHit(Projectile projectile)
        {
            OnProjectileHit?.Invoke(projectile);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void SetId()
        {
            this.id = 1;            
        }
        public int GetId()
        {
            return this.id;
        }
        public Memento GetMemento()
        {
            var copy = (Tank)this.Clone();
            copy.transform.position = new Vector2(this.transform.position.X, this.transform.position.Y);
            copy.brush = (Brush)this.brush.Clone();
            return new Memento(copy, this.id);
        }
        public void SetMemento(Memento previousState)
        {
            previousState.Restore(this);
        }
    }
}
