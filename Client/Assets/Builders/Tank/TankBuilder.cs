﻿using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    class TankBuilder : ITankBuilder
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
            tank.engine = new Engine(500);
            return this;
        }

        public ITankBuilder AddGun()
        {
            gun = new Gun(20)
            {
                reloadTime = 3,
                aimingTime = 2,
                rotationAngle = 0,
                spreadAngle = 10,
                minSpreadAngle = 10,
                maxSpreadAngle = 30
            };

            tank.turret.gun = gun;
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

            tank.suspension = suspension;
            return this;
        }

        public ITankBuilder AddTurret()
        {
            turret = new Turret()
            {
                rotationSpeed = 100,
                hitPoints = 800,
                reactionTime = 0.2f
            };

            tank.turret = turret;
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
