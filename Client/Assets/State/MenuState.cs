using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class MenuState : AbstractState
    {
        public override void stateOperation()
        {
            GameState.Instance.State = ClientState.Connecting;
            Networking.ConnectAsync();
        }
    }
}
