using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class IdleState : AbstractState
    {
        public override void stateOperation()
        {
            Console.WriteLine("Starting game");
        }
    }
}
