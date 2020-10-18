using System;

namespace Client
{
    class LookLeftCommand : ICommand
    {
        private IControllable controllable;

        public LookLeftCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.LookAt(-1);
        }

        public void Undo()
        {
            controllable.LookAt(1);
        }
    }
}
