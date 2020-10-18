using System;

namespace Client
{
    class Controller
    {
        private ICommand moveForwardCommand;
        private ICommand moveBackwardCommand;
        private ICommand turnLeftCommand;
        private ICommand turnRightCommand;
        private ICommand lookLeftCommand;
        private ICommand lookRightCommand;
        private ICommand actionCommand;

        private ICommand lastCommand;

        public Controller(IControllable controllable)
        {
            moveForwardCommand = new MoveForwardCommand(controllable);
            moveBackwardCommand = new MoveBackwardCommand(controllable);
            turnLeftCommand = new TurnLeftCommand(controllable);
            turnRightCommand = new TurnRightCommand(controllable);
            lookLeftCommand = new LookLeftCommand(controllable);
            lookRightCommand = new LookRightCommand(controllable);
            actionCommand = new ActionCommand(controllable);
        }

        public void MoveForward()
        {
            moveForwardCommand.Execute();
            lastCommand = moveForwardCommand;
        }

        public void MoveBackward()
        {
            moveBackwardCommand.Execute();
            lastCommand = moveBackwardCommand;
        }

        public void TurnLeft()
        {
            turnLeftCommand.Execute();
            lastCommand = turnLeftCommand;
        }

        public void TurnRight()
        {
            turnRightCommand.Execute();
            lastCommand = turnRightCommand;
        }

        public void LookLeft()
        {
            lookLeftCommand.Execute();
            lastCommand = lookLeftCommand;
        }

        public void LookRight()
        {
            lookRightCommand.Execute();
            lastCommand = lookRightCommand;
        }

        public void Action()
        {
            actionCommand.Execute();
            lastCommand = actionCommand;
        }

        public void Undo()
        {
            lastCommand?.Execute();
            lastCommand = null;
        }
    }
}
