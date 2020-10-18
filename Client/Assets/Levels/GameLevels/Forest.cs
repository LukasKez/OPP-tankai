﻿using PowerUp;

using System.Drawing;

namespace Client
{
    class Forest : GameLevel
    {
        public Forest(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
            : base(levelWidth, levelHeight, blockWidth, blockHeight, seed)
        {
            stuff.Add(new Ground(new Transform(0, 0, levelWidth, levelHeight), Brushes.LightGreen));


            // Horizontal borders

            GameObject gameObject = new Water(new Obstacle(0, 0, levelWidth, blockHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);

            gameObject = new Water(new Obstacle(0, levelHeight - blockHeight, levelWidth, blockHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);

            // Vertical borders

            gameObject = new Water(new Obstacle(0, 0, blockWidth, levelHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);

            gameObject = new Water(new Obstacle(levelWidth - blockWidth, 0, blockWidth, levelHeight));
            gameObject.Decorate();
            stuff.Add(gameObject);


            // Add PowerUp spawners
            stuff.Add(new PowerUpSpawner(blockWidth * 7, blockHeight * 4, blockWidth, blockWidth));
        }

    }
}
