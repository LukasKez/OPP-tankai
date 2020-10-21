using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Move : StrategyInterface
    {
        public void DoAction(ref Vector2 vertical, float speed, float deltaTime)
        {
            // Move backwards
            vertical.Y = speed * deltaTime;
        }
    }
}
