using System;
using System.Numerics;

namespace Client
{
    public class Suspension : GameObject
    {
        public float movementSpeedModifier;
        public float rotationSpeedModifier;
        public float loadLimit;

        private Track leftTrack;
        private Track rightTrack;

        public Suspension(Vector2 size, float movementSpeedModifier, float rotationSpeedModifier, float loadLimit)
        {
            this.movementSpeedModifier = movementSpeedModifier;
            this.rotationSpeedModifier = rotationSpeedModifier;
            this.loadLimit = loadLimit;

            leftTrack = new Track(-size.X / 2 + 2.5f, 0, size);
            rightTrack = new Track(size.X / 2 - 2.5f, 0, size);

            Instantiate(leftTrack, this);
            Instantiate(rightTrack, this);
        }
    }
}
