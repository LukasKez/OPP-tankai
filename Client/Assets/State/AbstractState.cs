using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class AbstractState
    {
        private AbstractState nextState;

        public void setNextState(AbstractState state)
        {
            this.nextState = state;
        }

        public void getNextState(GameState context)
        {
            context.setState(nextState);
        }

        public abstract void stateOperation();
    }
}
