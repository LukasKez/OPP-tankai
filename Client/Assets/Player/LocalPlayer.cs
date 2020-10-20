using PowerUp;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Client
{
    public class LocalPlayer : Player
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

        public override void Render(PaintEventArgs e)
        {
            base.Render(e);

            int pos = 110;
            e.Graphics.DrawString("Attack " + controllable.attack.ToString(), Control.DefaultFont, Brushes.Black, 20, pos);
            e.Graphics.DrawString("Defense " + controllable.defense.ToString(), Control.DefaultFont, Brushes.Black, 20, pos + 15);
            e.Graphics.DrawString("Health " + controllable.health.ToString(), Control.DefaultFont, Brushes.Black, 20, pos + 30);
            e.Graphics.DrawString("Speed " + controllable.speed.ToString(), Control.DefaultFont, Brushes.Black, 20, pos + 45);
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
