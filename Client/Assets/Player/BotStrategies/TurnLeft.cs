using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class TurnLeft : StrategyInterface
    {
        public void DoAction(TransformBase tr, ref Vector2 vertical, float speed, float deltaTime)
        {
            tr.rotation -= speed * deltaTime;
        }
    }
}