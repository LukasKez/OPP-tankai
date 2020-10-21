using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    interface StrategyInterface
    {
        void DoAction(ref Vector2 vertical, float speed, float deltaTime);
    }
}
