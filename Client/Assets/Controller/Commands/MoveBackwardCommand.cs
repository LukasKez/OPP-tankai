using System;

namespace Client
{
    class MoveBackwardCommand : ICommand
    {
        private IControllable controllable;

        public MoveBackwardCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.Move(1);
        }

        public void Undo()
        {
            controllable.Move(-1);
        }
    }
}
