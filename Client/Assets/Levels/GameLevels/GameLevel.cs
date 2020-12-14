using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Client
{
    public enum LevelType
    {
        Desert,
        Forest,
        Cave,
        Field,
    }

    public abstract class GameLevel : BaseGameLevel
    {
        public float levelWidth { get; private set; }
        public float levelHeight { get; private set; }

        public float blockWidth { get; private set; }
        public float blockHeight { get; private set; }

        public int seed { get; protected set; }

        protected HashSet<GameObject> stuff = new HashSet<GameObject>();

        private ConcurrentQueue<GameObject> toAdd = new ConcurrentQueue<GameObject>();
        private ConcurrentQueue<GameObject> toRemove = new ConcurrentQueue<GameObject>();

        protected IVisitor visitor;

        public GameLevel(float levelWidth, float levelHeight, float blockWidth, float blockHeight, int seed)
        {
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;

            this.blockWidth = blockWidth;
            this.blockHeight = blockHeight;

            this.seed = seed;
            

        }

        public void Add(GameObject gameObject)
        {
            toAdd.Enqueue(gameObject);
        }

        public void Remove(GameObject gameObject)
        {
            toRemove.Enqueue(gameObject);
        }

        public void HandleCollisions()
        {
            Physics.HandleCollisions(stuff);
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

        public void Render(Graphics g)
        {
            Renderer.Instance.RenderGameobjects(g, stuff, Options.shadows);
        }

        public List<T> Find<T>()
        {
            List<T> list = new List<T>();

            foreach (var thing in stuff)
            {
                if (thing is T item)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public void AddStuff(GameObject gameObject)
        {
            stuff.Add(gameObject);
        }
        
        public virtual void Accept(IVisitor v)
        {
            this.visitor = v;
        }

        public sealed override void SetUpLevel()
        {
            IVisitor v;

            v = new GroundVisitor();
            SetUpGround(v);

            v = new BorderVisitor();
            SetUpBorders(v);

            v = new ObstacleVisitor();
            SetUpObstacles(v);

            v = new SpawnerVisitor();
            SetUpSpawners(v);

        }
        public abstract void SetUpGround(IVisitor v);

        public abstract void SetUpBorders(IVisitor v);

        public abstract void SetUpObstacles(IVisitor v);

        public abstract void SetUpSpawners(IVisitor v);
    }
}
