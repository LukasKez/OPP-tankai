using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    class BotPlayer : Player
    {
        protected StrategyInterface action;

        private float elapsedTime;

        public BotPlayer()
        {
            controllable.transform.position = new Vector2(180, 200);
            controllable.brush = Brushes.Blue;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            UpdatePosition(deltaTime);
        }

        void UpdatePosition(float deltaTime)
        {
            Vector2 vertical = new Vector2();
            float speed = controllable.speed;
            Transform tr = controllable.transform;

            /*// Example of strategy call
            action = new Move();
            action.DoAction();

            action = new Turn();
            action.DoAction();
            */

            elapsedTime += deltaTime;

            // Test bot move
            action = new Move();
            action.DoAction(ref vertical, speed, deltaTime);

            if (elapsedTime >= 2f)
            {
                action.DoAction(ref vertical, -speed, deltaTime);
                if (elapsedTime >= 4f)
                    elapsedTime = 0f;
            }

            tr.position += Utils.Rotate(vertical, tr.rotation);
            controllable.transform = tr;
        }
    }
}
