using Client.Obstacles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.Assets.Levels.GameLevels
{
    abstract class GameLevel
    {
        public float levelWidth { get; private set; }
        public float levelHeight { get; private set; }

        public float blockWidth { get; private set; }
        public float blockHeight { get; private set; }

        public int seed { get; protected set; }

        protected HashSet<GameObject> stuff = new HashSet<GameObject>();

        public GameLevel(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;

            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;

            this.seed = seed;
        }

        public void SetupObstacles(string levelType)
        {
            int vertEnd = (int)(levelWidth / blockWidth);
            int hozEnd = (int)(levelHeight / blockHeight);

            seed %= 4;

            for (int k = 3; k <= hozEnd - 2; k += 2)
            {
                for (int z = 4; z < vertEnd; z += seed + 6)
                {
                    if (seed == 0)
                    {
                        stuff.Add(new Boulder((z + seed) * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        seed++;
                    }
                    else if (seed == 1)
                    {
                        stuff.Add(new Water(z * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        seed++;
                    }
                    else if (seed == 2)
                    {
                        stuff.Add(new Tree((z - seed) * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        seed++;
                    }
                    else if (seed == 3)
                    {
                        stuff.Add(new Wall(z * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        seed++;
                    }
                    seed %= 4;
                }
            }
        }

        public bool Add(GameObject gameObject)
        {
            return stuff.Add(gameObject);
        }

        public bool Remove(GameObject gameObject)
        {
            return stuff.Remove(gameObject);
        }

        public GameObject GetCollision(GameObject gameObject)
        {
            Transform transform = gameObject.transform - (float)gameObject.transform.size.X * 0.2f;

            foreach (GameObject thing in stuff)
            {
                if (thing.collider == ColliderType.None)
                {
                    continue;
                }

                if (CheckCollision(transform, thing.transform) == true)
                {
                    return thing;
                }
            }
            return null;
        }

        private bool CheckCollision(Transform rect1, Transform rect2)
        {
            if (rect1.position.X < rect2.position.X + rect2.size.X &&
                rect1.position.X + rect1.size.X > rect2.position.X &&
                rect1.position.Y < rect2.position.Y + rect2.size.Y &&
                rect1.position.Y + rect1.size.Y > rect2.position.Y)
            {
                return true;
            }

            return false;
        }

        public void Update(float deltaTime)
        {
            foreach (var thing in stuff)
            {
                thing.Update(deltaTime);
            }
        }

        public void Render(PaintEventArgs e)
        {
            foreach (var thing in stuff)
            {
                thing.Render(e);
            }
        }
    }
}
