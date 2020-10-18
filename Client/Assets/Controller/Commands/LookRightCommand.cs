using System;

namespace Client
{
    class LookRightCommand : ICommand
    {
        private IControllable controllable;

        public LookRightCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.LookAt(1);
        }

        public void Undo()
        {
            controllable.LookAt(-1);
        }
    }
}
