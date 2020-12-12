using Server.Hubs;
using System;

namespace Server
{
    public class FullLobbyValidator : Validator
    {
        protected override bool Validation(GameHub hub)
        {
            return GameHandler.players.Count < GameHandler.maxPlayerCount;
        }
    }
}
