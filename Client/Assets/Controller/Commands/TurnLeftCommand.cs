using System;

namespace Client
{
    class TurnLeftCommand : ICommand
    {
        private IControllable controllable;

        public TurnLeftCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.Rotate(-1);
        }

        public void Undo()
        {
            controllable.Rotate(1);
        }
    }
}
