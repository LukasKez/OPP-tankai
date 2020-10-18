using System;

namespace Client
{
    class TurnRightCommand : ICommand
    {
        private IControllable controllable;

        public TurnRightCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.Rotate(1);
        }

        public void Undo()
        {
            controllable.Rotate(-1);
        }
    }
}
