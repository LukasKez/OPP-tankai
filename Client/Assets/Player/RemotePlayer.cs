using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class RemotePlayer : Player
    {
        public void UpdatePosition(float x, float y, float r)
        {
            controllable.transform.position.X = x;
            controllable.transform.position.Y = y;
            controllable.transform.rotation = r;
        }
    }
}
