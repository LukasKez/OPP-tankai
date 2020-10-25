using System;
using System.Drawing;
using System.Numerics;

namespace Client
{
    class TankBuilder : ITankBuilder
    {
        private Tank tank;

        public ITankBuilder AddHull(float x, float y)
        {
            tank = new Tank(new Transform(x, y, 20, 22), Brushes.Red);
            return this;
        }

        public ITankBuilder AddEngine()
        {
            tank.engine = new Engine(500);
            return this;
        }

        public ITankBuilder AddGun()
        {
            tank.turret.gun = new Gun(3, 1, 0);
            return this;
        }

        public ITankBuilder AddSuspension()
        {
            Vector2 size = tank.transform.size;
            Suspension suspension = new Suspension(size, 1, 1, 30);
            suspension.transform.parent = tank.transform;
            tank.suspension = suspension;
            return this;
        }

        public ITankBuilder AddTurret()
        {
            tank.turret = new Turret(100, 800);
            return this;
        }

        public Tank GetResult()
        {
            return tank;
        }
    }
}
