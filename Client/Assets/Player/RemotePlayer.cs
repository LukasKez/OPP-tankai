using System;

namespace Client
{
    class RemotePlayer : Player
    {
        public string name;
        public bool isReady;

        public void UpdatePosition(float x, float y, float r)
        {
            controllable.transform.position.X = x;
            controllable.transform.position.Y = y;
            controllable.transform.rotation = r;
        }
    }
}
