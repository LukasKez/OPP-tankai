using Client.Assets.State;
using System;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    public enum ClientState
    {
        Menu,
        Connecting,
        Connected,
        Ready,
        Playing,
        Died,
    }

    public class GameState : Subject
    {
        public bool focused;
        public Vector2 mapSize;
        public Vector2 mouseLocation;
        public GameLevel gameLevel;
        public TankType tankType;
        public int RandomSeed;

        private ClientState state;

        public AbstractState currentState;
        public ClientState State
        {
            get { return state; }
            set
            {
                state = value;
                Notify();
            }
        }

        public event Action<MouseButtons> OnMouseClicked;

        public void MouseClicked(MouseButtons button)
        {
            OnMouseClicked?.Invoke(button);
        }

        private static readonly GameState instance = new GameState();
        public static GameState Instance
        {
            get { return instance; }
        }

        public GameState()
        {
            mapSize = new Vector2(800, 600);

            AbstractState idleState = new IdleState();
            AbstractState menuState = new MenuState();
            AbstractState connectedState = new ConnectedState();
            AbstractState readyState = new ReadyState();
            AbstractState diedState = new DiedState();

            idleState.setNextState(menuState);
            menuState.setNextState(connectedState);
            connectedState.setNextState(readyState);
            readyState.setNextState(diedState);
            diedState.setNextState(menuState);

            currentState = idleState;
        }

        public AbstractState operate()
        {
            currentState.getNextState(this);
            currentState.stateOperation();
            return currentState;
        }

        public void setState(AbstractState nextState)
        {
            this.currentState = nextState;
        }
    }
}
