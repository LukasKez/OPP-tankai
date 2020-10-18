using System;

namespace Client
{
    public class Suspension
    {
        public float movementSpeedModifier;
        public float rotationSpeedModifier;
        public float loadLimit;

        private Track leftTrack;
        private Track rightTrack;

        public Suspension(float movementSpeedModifier, float rotationSpeedModifier, float loadLimit)
        {
            this.movementSpeedModifier = movementSpeedModifier;
            this.rotationSpeedModifier = rotationSpeedModifier;
            this.loadLimit = loadLimit;

            leftTrack = new Track();
            rightTrack = new Track();
        }
    }
}
