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
    public enum BotState
    {
        Alive,
        Dead,
    }

    class BotPlayer : Player
    {
        protected StrategyInterface action;

        private float elapsedTime;

        private bool alive = true;

        Caretaker caretaker;

        public BotPlayer()
        {
            Spawn();

            controllable.transform.position = new Vector2(180, 200);
            controllable.brush = Brushes.Blue;

            controllable.SetId();
            caretaker = new Caretaker();
            caretaker.AddMemento(controllable.GetMemento());


        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            elapsedTime += deltaTime;

            if(alive==true)
            {
                UpdatePosition(deltaTime);
            }
            else
            {
                controllable.health += 50;
                if(controllable.health>=100)
                {
                    RestoreBotTank();
                    alive = true;
                }
            }


        }

        void UpdatePosition(float deltaTime)
        {
            Vector2 vertical = new Vector2();
            float speed = controllable.speed;
            TransformBase tr = controllable.transform;
            
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
                //Memento
                controllable.health -= 50;
                alive = false;
            }

            tr.position += Utils.Rotate(vertical, tr.rotation);
            controllable.transform = tr;
        }
        private void TestMemento()
        {
            controllable.health -= 50;
            if (controllable.health<=0)
            {
                GameState.Instance.gameLevel.Remove(controllable);
                alive = false;
            }
        }
        
        public void RemoveBotTank()
        {
            GameState.Instance.gameLevel.Remove(controllable);
        }
        public void RestoreBotTank()
        {
            controllable.SetMemento(caretaker.GetMemento(0));
            GameState.Instance.gameLevel.Add(controllable);
        }
        private void OnProjectileHit(Projectile projectile)
        {
            controllable.TakeDamage(projectile.damage);
            
            // TODO: Send update to the server
        }
    }
}
