using Server.Hubs;
using System;

namespace Server
{
    public class SameNameValidator : Validator
    {
        protected override bool Validation(GameHub hub)
        {
            GameHandler.players.TryGetValue(hub.Context.ConnectionId, out GameHandler.PlayerStats clientPlayer);

            if (clientPlayer.name == null)
            {
                clientPlayer.name = "Player";
            }

            string newName = clientPlayer.name;
            bool unique = true;
            int sufix = 1;

            while (true)
            {
                foreach (var player in GameHandler.players)
                {
                    if (player.Value.name == newName && player.Key != hub.Context.ConnectionId)
                    {
                        unique = false;
                        break;
                    }
                }

                if (!unique)
                {
                    newName = $"{clientPlayer.name}{sufix++}";
                    unique = true;
                    continue;
                }
                break;
            }

            if (newName != clientPlayer.name)
            {
                _ = hub.OverrideName(newName);
            }
            return true;
        }
    }
}
