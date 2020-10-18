using System;

namespace Client
{
    class MoveForwardCommand : ICommand
    {
        private IControllable controllable;

        public MoveForwardCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.Move(-1);
        }

        public void Undo()
        {
            controllable.Move(1);
        }
    }
}
