using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace Client
{
    public class LocalPlayer : Player
    {
        private Controller tankController;

        private float elapsedTime;
        private float updateRate = 0.1f;
        private float crosshairLength = 20;
        private Pen crosshair;

        public LocalPlayer(PlayerSpawner spawnPoint) : base(spawnPoint)
        {
            tankType = GameState.Instance.tankType;
            Spawn();

            crosshair = new Pen(Color.FromArgb(128, Color.Red), 2);
            tankController = new Controller(controllable);

            GameState.Instance.OnMouseClicked += OnMouseClicked;
            controllable.OnProjectileHit += OnProjectileHit;
        }

        ~LocalPlayer()
        {
            GameState.Instance.OnMouseClicked -= OnMouseClicked;
            controllable.OnProjectileHit -= OnProjectileHit;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (GameState.Instance.State != ClientState.Died)
            {
                if (GameState.Instance.focused)
                    UpdatePosition();
                UpdateLooking();
            }

            elapsedTime += deltaTime;
            if (elapsedTime >= updateRate)
            {
                elapsedTime = 0f;
                Networking.SendPositionUpdateAsync(controllable);
            }
        }

        private void UpdatePosition()
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

        private void UpdateLooking()
        {
            Vector2 mousePosition = GameState.Instance.mouseLocation - controllable.transform.position;
            float turretAngle = controllable.Turret.transform.WorldRotation;
            float dotProduct = Vector2.Dot(mousePosition, Utils.RotatedVector(turretAngle));

            if (dotProduct < -1)
            {
                tankController.LookLeft();
            }
            else if (dotProduct > 1)
            {
                tankController.LookRight();
            }
            else
            {
                tankController.StopLooking();
            }
        }

        public void OnMouseClicked(MouseButtons button)
        {
            if (GameState.Instance.State == ClientState.Died)
                return;

            if (button == MouseButtons.Left)
            {
                tankController.Action();
            }
        }

        private void OnProjectileHit(Projectile projectile)
        {
            controllable.TakeDamage(projectile.damage);

            // TODO: Send update to the server
        }

        public override void Render(Graphics g)
        {
            base.Render(g);

            DrawStats(g);
            DrawCrosshair(g);
        }

        private void DrawStats(Graphics g)
        {
            int pos = 110;
            g.DrawString("Attack " + controllable.attack.ToString(), Control.DefaultFont, Brushes.Black, 20, pos);
            g.DrawString("Defense " + controllable.defense.ToString(), Control.DefaultFont, Brushes.Black, 20, pos + 15);
            g.DrawString("Health " + controllable.health.ToString(), Control.DefaultFont, Brushes.Black, 20, pos + 30);
            g.DrawString("Speed " + controllable.speed.ToString(), Control.DefaultFont, Brushes.Black, 20, pos + 45);
        }

        private void DrawCrosshair(Graphics g)
        {
            Vector2 position = controllable.transform.position;
            Vector2 mousePosition = GameState.Instance.mouseLocation - position;

            float turretAngle = controllable.Turret.transform.WorldRotation - 90;
            float spreadAngle = controllable.Turret.gun.spreadAngle;

            float mouseLength = mousePosition.Length();
            float lenght1 = Math.Max(mouseLength, crosshairLength + 30);
            float lenght2 = Math.Max(mouseLength, lenght1 - crosshairLength);

            Vector2 point1 = Utils.RotatedVector(turretAngle + spreadAngle, lenght1 - crosshairLength) + position;
            Vector2 point2 = Utils.RotatedVector(turretAngle + spreadAngle, lenght2 + crosshairLength) + position;
            g.DrawLine(crosshair, point1.X, point1.Y, point2.X, point2.Y);

            point1 = Utils.RotatedVector(turretAngle - spreadAngle, lenght1 - crosshairLength) + position;
            point2 = Utils.RotatedVector(turretAngle - spreadAngle, lenght2 + crosshairLength) + position;
            g.DrawLine(crosshair, point1.X, point1.Y, point2.X, point2.Y);

            point1 = Utils.RotatedVector(turretAngle, lenght2) + position;
            g.DrawArc(crosshair, point1.X - 3, point1.Y - 3, 6, 6, turretAngle - 90, 180);
        }

        public void SetPosition(int x, int y)
        {
            controllable.transform.position = new Vector2(x, y);
        }
    }
}
