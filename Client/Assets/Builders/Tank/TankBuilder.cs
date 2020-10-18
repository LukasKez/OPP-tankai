using System;
using System.Drawing;

namespace Client
{
    class TankBuilder : ITankBuilder
    {
        private Tank tank;

        public ITankBuilder AddHull(float x, float y)
        {
            tank = new Tank(x, y, Brushes.Red);
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
            tank.suspension = new Suspension(1, 1, 30);
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
