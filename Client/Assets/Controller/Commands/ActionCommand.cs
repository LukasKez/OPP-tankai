using System;

namespace Client
{
    class ActionCommand : ICommand
    {
        private IControllable controllable;

        public ActionCommand(IControllable controllable)
        {
            this.controllable = controllable;
        }

        public void Execute()
        {
            controllable.Action();
        }

        public void Undo()
        {
        }
    }
}
