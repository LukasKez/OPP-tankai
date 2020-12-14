using System.Drawing;
using System.Numerics;

namespace Client
{
    public class Memento 
    {
        private Tank state;
        private int id;
        public Memento(Tank stateToSave,int id)
        {
            state = stateToSave;
            this.id = id;
        }
        public void Restore(Tank tank)
        {
            if(tank.GetId()==this.id)
            {
                tank.health = state.health;
                tank.speed = state.speed;
                tank.attack = state.attack;
                tank.defense = state.defense;

                tank.transform = state.transform;
                tank.transform.position = new Vector2(state.transform.position.X, state.transform.position.Y);
                tank.transform.size = new Vector2(state.transform.size.X, state.transform.size.Y);
            }
        }
    }
}
