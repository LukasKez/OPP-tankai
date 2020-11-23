using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class LightTankBuilder : ITankBuilder
    {
        private Tank tank;
        private Suspension suspension;
        private Turret turret;
        private Gun gun;

        public ITankBuilder AddHull(float x, float y)
        {
            Transform tr = new Transform(x, y, 18, 20);
            tank = new Tank(tr, Brushes.Orange);
            return this;
        }

        public ITankBuilder AddEngine()
        {
            tank.engine = new Engine(500);
            return this;
        }

        public ITankBuilder AddSuspension()
        {
            Vector2 size = tank.transform.size;
            suspension = new Suspension(size)
            {
                movementSpeedModifier = 1.5f,
                rotationSpeedModifier = 1.5f,
                loadLimit = 20
            };

            tank.suspension = suspension;
            return this;
        }

        public ITankBuilder AddTurret()
        {
            turret = new Turret(new Vector2(17, 17))
            {
                rotationSpeed = 80,
                hitPoints = 500,
                reactionTime = 0.2f
            };

            tank.turret = turret;
            return this;
        }

        public ITankBuilder AddGun()
        {
            Projectile projectile = new Projectile()
            {
                damage = 10,
                speed = 600,
                bounceAngle = 50,
                bounceCount = 1,
            };

            gun = new Gun(18)
            {
                shell = projectile,
                reloadTime = 1.5f,
                aimingRate = 10,
                rotationAngle = 0,
                minSpreadAngle = 7,
                maxSpreadAngle = 27
            };

            tank.turret.gun = gun;
            return this;
        }

        public Tank GetResult()
        {
            suspension.InstantiateTracks();
            GameObject.Instantiate(suspension, tank);
            GameObject.Instantiate(tank);
            GameObject.Instantiate(gun, turret);
            GameObject.Instantiate(turret, tank);
            return tank;
        }
    }
}
