using System;

namespace Client
{
    class StopLookingCommand : ICommand
    {
        private IControllable controllable;

        public StopLookingCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.LookAt(0);
        }

        public void Undo()
        {
        }
    }
}
