using System;
using System.Numerics;

namespace Client
{
    class TurnRight : StrategyInterface
    {
        public void DoAction(TransformBase tr, ref Vector2 vertical, float speed, float deltaTime)
        {
            tr.rotation += speed * deltaTime;
        }
    }
}