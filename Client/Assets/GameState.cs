using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class GameState
    {
        public bool focused;

        private static readonly GameState instance = new GameState();
        public static GameState Instance
        {
            get { return instance; }
        }
    }
}
