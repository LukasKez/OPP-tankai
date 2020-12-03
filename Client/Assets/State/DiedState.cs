using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assets.State
{
    class DiedState : AbstractState
    {
        public override void stateOperation()
        {
            Networking.DisconnectAsync();
        }
    }
}
