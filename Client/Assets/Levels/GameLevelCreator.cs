using System;

namespace Client
{
    class GameLevelCreator
    {
        public GameLevelCreator()
        {

        }

        static public GameLevel GetGameLevel(LevelType levelType, float levelWidth, float levelHight, float blockWidth, float blockHeight, int seed)
        {
            GameLevel gameLevel;
            switch (levelType)
            {
                case LevelType.Desert:
                    gameLevel = new Desert(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
                case LevelType.Forest:
                    gameLevel = new Forest(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
                case LevelType.Cave:
                    gameLevel = new Cave(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
                case LevelType.Field:
                default:
                    gameLevel = new Field(levelWidth, levelHight, blockWidth, blockHeight, seed);
                    break;
            }
            gameLevel.SetupObstacles(levelType);
            return gameLevel;
        }
    }
}
