using System;

namespace Client
{
    public class Turret : GameObject
    {
        public float rotationSpeed;
        public float hitPoints;

        public Gun gun { get; set; }

        public Turret(float rotationSpeed, float hitPoints)
        {
            this.rotationSpeed = rotationSpeed;
            this.hitPoints = hitPoints;
        }
    }
}
