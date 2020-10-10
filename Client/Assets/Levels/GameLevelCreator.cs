using Client.Assets.Levels.GameLevels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Assets.Levels
{
    class GameLevelCreator
    {
        public GameLevelCreator()
        {

        }

        static public GameLevel GetGameLevel(string levelType, float levelWidth, float levelHight, float blockWidth, float blockHeight, int seed)
        {
            GameLevel gameLevel = null;
            switch (levelType.ToLower())
            {
                case "desert":
                    gameLevel = new Desert(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
                case "forest":
                    gameLevel = new Forest(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
                case "cave":
                    gameLevel = new Cave(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
                default:
                    gameLevel = new Field(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
            }
            gameLevel.SetupObstacles(levelType);
            return gameLevel;
        }
    }
}
