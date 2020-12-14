using System;
using System.Numerics;

namespace Client
{
    public class Suspension : GameObject
    {
        public float movementSpeedModifier;
        public float rotationSpeedModifier;
        public float loadLimit;

        public Track leftTrack { get; private set; }
        public Track rightTrack { get; private set; }

        public Suspension(Vector2 size)
        {
            leftTrack = new Track(-size.X / 2 + 2f, 0, size);
            rightTrack = new Track(size.X / 2 - 2f, 0, size);
        }

        public void InstantiateTracks()
        {
            Instantiate(leftTrack, this);
            Instantiate(rightTrack, this);
        }
    }
}
