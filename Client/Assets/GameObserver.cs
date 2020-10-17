using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    static class GameObserver
    {
        public static event Action<ClientState> OnGameStateChange;

        public static void GameStateChange(ClientState newState)
        {
            OnGameStateChange?.Invoke(newState);
        }
    }
}
