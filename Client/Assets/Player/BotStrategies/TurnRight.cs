﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class TurnRight : StrategyInterface
    {
        public void DoAction(Transform tr, ref Vector2 vertical, float speed, float deltaTime)
        {
            tr.rotation += speed * deltaTime;
        }
    }
}