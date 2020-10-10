using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    class Bot : AbstractBot
    {
        protected StrategyInterface action;

        private float elapsedTime = 0f;
        private float updateRate = 1f / 40f;

        float timePassed = 0;

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (GameState.Instance.focused)
                UpdatePosition(deltaTime);

            elapsedTime += deltaTime;
            if (elapsedTime > updateRate)
            {
                elapsedTime -= updateRate;
                Networking.SendPositionUpdateAsync(controllable);
            }
        }

        void UpdatePosition(float deltaTime)
        {
            Vector vertical = new Vector();
            float speed = controllable.speed;
            Transform tr = controllable.transform;

            /*// Example of strategy call
            action = new Move();
            action.DoAction();

            action = new Turn();
            action.DoAction();
            */

            timePassed += deltaTime;

            // Test bot move
            action = new Move();
            action.DoAction(ref vertical, speed, deltaTime);

            if (timePassed > 2)
            {
                vertical.Y = -speed * deltaTime;
            }
            
            double radians = tr.rotation * Math.PI / 180;
            tr.position.X += vertical.X * Math.Cos(radians) - vertical.Y * Math.Sin(radians);
            tr.position.Y += vertical.X * Math.Sin(radians) + vertical.Y * Math.Cos(radians);
            controllable.transform = tr;
        }
    }
}
