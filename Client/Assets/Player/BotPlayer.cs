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
        private float deadTime;

        private bool alive = true;

        Caretaker caretaker;

        public BotPlayer()
        {
            Spawn();

            controllable.transform.position = new Vector2(180, 200);
            controllable.brush = Brushes.Blue;

            controllable.OnProjectileHit += OnProjectileHit;

            controllable.SetId();
            caretaker = new Caretaker();

            controllable.health = 1;
            controllable.defense = 0;
            caretaker.AddMemento(controllable.GetMemento());
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            


            if (alive==true)
            {
                elapsedTime += deltaTime;
                UpdatePosition(deltaTime);
                if (controllable.health <= 0)
                {
                    RemoveBotTank();
                    alive = false;
                    elapsedTime = 0;
                }
            }
            else
            {
                deadTime += deltaTime;
                if (deadTime >= 4.8f)
                {
                    RestoreBotTank();
                    alive = true;
                    deadTime = 0;
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
            }

            tr.position += Utils.Rotate(vertical, tr.rotation);
            controllable.transform = tr;
        }
        
        public void RemoveBotTank()
        {

            GameState.Instance.gameLevel.Remove(controllable.Suspension.rightTrack);
            GameState.Instance.gameLevel.Remove(controllable.Suspension.leftTrack);

            GameState.Instance.gameLevel.Remove(controllable.Suspension);

            GameState.Instance.gameLevel.Remove(controllable);

            GameState.Instance.gameLevel.Remove(controllable.Turret);

            GameState.Instance.gameLevel.Remove(controllable.Turret.gun);
        }
        public void RestoreBotTank()
        {
            controllable.SetMemento(caretaker.GetMemento(0));

            controllable.transform.position = new Vector2(180, 200);
            controllable.Suspension.InstantiateTracks();
            GameObject.Instantiate(controllable.Suspension, controllable);
            GameObject.Instantiate(controllable);
            GameObject.Instantiate(controllable.Turret.gun, controllable.Turret);
            GameObject.Instantiate(controllable.Turret, controllable);
        }
        private void OnProjectileHit(Projectile projectile)
        {
            controllable.health -= projectile.damage;
            
            // TODO: Send update to the server
        }
    }
}
