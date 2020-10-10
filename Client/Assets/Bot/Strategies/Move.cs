using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    class Move : StrategyInterface
    {
        public void DoAction(ref Vector vertical, float speed, float deltaTime)
        {
            // Move backwards
            vertical.Y = speed * deltaTime;
        }
    }
}
