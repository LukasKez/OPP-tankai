using System;

namespace Client
{
    public class Gun : GameObject
    {
        public float reloadTime;
        public float aimingTime;
        public float angle;

        public Gun(float reloadTime, float aimingTime, float angle)
        {
            this.reloadTime = reloadTime;
            this.aimingTime = aimingTime;
            this.angle = angle;
        }
    }
}
