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
        public GameLevel GetGameLevel(string levelType,float levelWidth,float levelHight, float blockWidth, float blockHeight)
        {                
            GameLevel gameLevel = null;
            switch (levelType.ToLower())
            {
                case "desert":
                    gameLevel = new Desert(levelWidth, levelHight, blockWidth, blockHeight);

                    break;
                case "forest":
                    gameLevel = new Forest(levelWidth, levelHight, blockWidth, blockHeight);
                    break;
                case "cave":
                    gameLevel = new Cave(levelWidth, levelHight, blockWidth, blockHeight);
                    break;
                default:
                    gameLevel = new Field(levelWidth, levelHight, blockWidth, blockHeight);
                    break;
            }
            gameLevel.SetupBorder(levelType);
            return gameLevel;
        }
    }
}
