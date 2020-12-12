using Server.Hubs;
using System;

namespace Server
{
    public class GameStartedValidator : Validator
    {
        protected override bool Validation(GameHub hub)
        {
            return !GameHandler.isGameStarted;
        }
    }
}
