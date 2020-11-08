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

            elapsedTime += deltaTime;

            // Test strategy pattern
            if (elapsedTime < 3f) {
                action = new MoveForward();
                action.DoAction(tr, ref vertical, speed, deltaTime);
            } else if (elapsedTime >= 3f && elapsedTime < 4.8f) 
            {
                action = new TurnRight();
                action.DoAction(tr, ref vertical, speed, deltaTime);
            } else if (elapsedTime >= 4.8f && elapsedTime < 6.6f)
            {
                action = new TurnLeft();
                action.DoAction(tr, ref vertical, speed, deltaTime);
            } else if (elapsedTime >= 6.6f && elapsedTime < 9.6f)
            {
                action = new MoveBackwards();
                action.DoAction(tr, ref vertical, speed, deltaTime);
            } else if (elapsedTime >= 9.6f)
            {
                elapsedTime = 0;
            }

            tr.position += Utils.Rotate(vertical, tr.rotation);
            controllable.transform = tr;
        }
    }
}
