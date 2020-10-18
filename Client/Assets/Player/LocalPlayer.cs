using PowerUp;
using System;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    class LocalPlayer : Player
    {
        private Controller tankController;

        private float elapsedTime = 0f;
        private float updateRate = 1f / 40f;

        public LocalPlayer()
        {
            tankController = new Controller(controllable);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (GameState.Instance.focused)
                UpdatePosition();

            elapsedTime += deltaTime;
            if (elapsedTime > updateRate)
            {
                elapsedTime -= updateRate;
                Networking.SendPositionUpdateAsync(controllable);
            }
        }

        void UpdatePosition()
        {
            if (Keyboard.IsKeyDown(Key.A))
            {
                tankController.TurnLeft();
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                tankController.TurnRight();
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                tankController.MoveForward();
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                tankController.MoveBackward();
            }
        }
    }
}
