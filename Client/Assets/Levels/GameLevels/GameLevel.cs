using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    public enum LevelType
    {
        Desert,
        Forest,
        Cave,
        Field,
    }

    abstract class GameLevel
    {
        public float levelWidth { get; private set; }
        public float levelHeight { get; private set; }

        public float blockWidth { get; private set; }
        public float blockHeight { get; private set; }

        public int seed { get; protected set; }

        protected HashSet<GameObject> stuff = new HashSet<GameObject>();

        private ConcurrentQueue<GameObject> toAdd = new ConcurrentQueue<GameObject>();
        private ConcurrentQueue<GameObject> toRemove = new ConcurrentQueue<GameObject>();

        readonly Brush shadowBrush = new SolidBrush(Color.FromArgb(64, Color.Black));
        readonly Vector2 sunDirection = new Vector2(2, 2);



        public GameLevel(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;

            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;

            this.seed = seed;

        }

        public void SetupObstacles(LevelType levelType)
        {
            int vertEnd = (int)(levelWidth / blockWidth);
            int hozEnd = (int)(levelHeight / blockHeight);

            seed %= 4;

            for (int k = 4; k <= hozEnd - 2; k += 3)
            {
                for (int z = 6; z < vertEnd; z += seed + 6)
                {
                    if (seed == 0)
                    {
                        GameObject gameObject = new DamageObstacle(new Boulder(new Obstacle((z + seed) * blockWidth, k * blockHeight, blockWidth, blockHeight)));
                        gameObject.Decorate();
                        stuff.Add(gameObject);
                        seed++;
                    }
                    else if (seed == 1)
                    {

                        GameObject gameObject = new Water(new Obstacle(z * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        gameObject.Decorate();
                        stuff.Add(gameObject);
                        seed++;
                    }
                    else if (seed == 2)
                    {

                        GameObject gameObject = new Tree(new Obstacle((z - seed) * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        gameObject.Decorate();
                        stuff.Add(gameObject);
                        seed++;
                    }
                    else if (seed == 3)
                    {
                        GameObject gameObject = new Wall(new Obstacle(z * blockWidth, k * blockHeight, blockWidth, blockHeight));
                        gameObject.Decorate();
                        stuff.Add(gameObject);
                        seed++;
                    }
                    seed %= 4;
                }
            }
        }

        public void Add(GameObject gameObject)
        {
            toAdd.Enqueue(gameObject);
        }

        public void Remove(GameObject gameObject)
        {
            toRemove.Enqueue(gameObject);
        }

        public GameObject GetCollision(GameObject gameObject)
        {
            Transform transform = gameObject.transform - gameObject.transform.size.X * 0.2f;

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
            UpdateStuff();
        }

        private void UpdateStuff()
        {
            for (; 0 < toAdd.Count;)
            {
                toAdd.TryDequeue(out GameObject obj);
                stuff.Add(obj);
            }

            for (; 0 < toRemove.Count;)
            {
                toRemove.TryDequeue(out GameObject obj);
                stuff.Remove(obj);
            }
        }

        public void Render(PaintEventArgs e)
        {
            foreach (var thing in stuff)
            {
                if (!thing.isShadowCaster)
                {
                    thing.Render(e);
                }
            }

            if (Options.shadows)
            {
                RenderShadows(e);
            }

            foreach (var thing in stuff)
            {
                if (thing.isShadowCaster)
                {
                    thing.Render(e);
                }
            }
        }

        private void RenderShadows(PaintEventArgs e)
        {
            foreach (var thing in stuff)
            {
                if (thing.isShadowCaster)
                {
                    Transform shadow = thing.transform;
                    shadow.position += sunDirection;

                    Renderer.RenderShape(e, shadowBrush, shadow, thing.shape);
                }
            }
        }
    }
}
