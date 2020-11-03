using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class PlayerSpawner : GameObject
    {
        public PlayerSpawner(float x, float y, float r = 0)
        {
            transform.position.X = x;
            transform.position.Y = y;
            transform.rotation = r;
        }
    }
}
