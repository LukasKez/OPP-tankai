﻿using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public class HeavyTankBuilder : ITankBuilder
    {
        private Tank tank;
        private Suspension suspension;
        private Turret turret;
        private Gun gun;

        public ITankBuilder AddHull(float x, float y)
        {
            Transform tr = new Transform(x, y, 20, 22);
            tank = new Tank(tr, Brushes.Red);
            return this;
        }

        public ITankBuilder AddEngine()
        {
            tank.Engine = new Engine(500);
            return this;
        }

        public ITankBuilder AddSuspension()
        {
            Vector2 size = tank.transform.size;
            suspension = new Suspension(size)
            {
                movementSpeedModifier = 1,
                rotationSpeedModifier = 1,
                loadLimit = 30
            };

            tank.Suspension = suspension;
            return this;
        }

        public ITankBuilder AddTurret()
        {
            turret = new Turret(new Vector2(19, 19))
            {
                rotationSpeed = 60,
                hitPoints = 800,
                reactionTime = 0.2f
            };

            tank.Turret = turret;
            return this;
        }

        public ITankBuilder AddGun()
        {
            Projectile projectile = new Projectile()
            {
                damage = 20,
                speed = 600,
                bounceAngle = 45,
                bounceCount = 1,
            };

            gun = new Gun(20)
            {
                shell = projectile,
                reloadTime = 3,
                aimingRate = 10,
                rotationAngle = 0,
                minSpreadAngle = 7,
                maxSpreadAngle = 27
            };

            tank.Turret.gun = gun;
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
