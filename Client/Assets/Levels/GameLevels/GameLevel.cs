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
            int i = 0;
            int k = 2;

            int vertEnd = (int)(levelWidth / blockWidth);
            int hozEnd = (int)(levelHeight / blockHeight);

            seed %= 4;

            while (i < vertEnd || i < hozEnd)
            {
                i++;

                if (k <= hozEnd - 2)
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
                    k += 2;
                }
            }

        }

        public GameObject Get(GameObject gameObject)
        {
            var cords = new float[] { (float)(gameObject.transform.position.X + gameObject.transform.size.X / 2), (float)(gameObject.transform.position.Y + gameObject.transform.size.Y / 2) };

            foreach (GameObject thing in stuff)
            {
                if (CheckGameObject(thing, cords) == true)
                {
                    return thing;
                }
            }
            return null;
        }

        public bool Add(GameObject gameObject)
        {
            return stuff.Add(gameObject);
        }

        public bool Remove(GameObject gameObject)
        {
            return stuff.Remove(gameObject);
        }

        private bool CheckGameObject(GameObject gameObject, float[] coordinate)
        {
            if (coordinate[0] > gameObject.transform.position.X && coordinate[0] < (gameObject.transform.position.X + gameObject.transform.size.X))
            {
                if (coordinate[0] > gameObject.transform.position.Y && coordinate[0] < (gameObject.transform.position.Y + gameObject.transform.size.Y))
                {
                    return true;
                }
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
