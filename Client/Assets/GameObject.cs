using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    public enum Shape
    {
        None,
        Rectangle,
        Ellipse,
        Mesh,
    }

    public enum ColliderType
    {
        None,
        Collider,
        Trigger,
    }

    public abstract class GameObject
    {
        private Renderer renderer = new Renderer();

        public Transform transform;
        public Shape shape;
        public ColliderType collider;
        public bool isStatic;
        public bool isShadowCaster;

        private BoxAABB _AABB;
        public BoxAABB AABB
        {
            get => _AABB + transform.position;
            private set => _AABB = value;
        }

        public Brush brush;
        public Pen outlinePen;

        public float damage;

        protected GameObject() : this(new Transform())
        {
        }

        protected GameObject(Transform transform)
        {
            this.transform = transform;
            GenerateAABB();
        }

        [Obsolete()]
        protected GameObject(float x, float y, float w = 1, float h = 1, float r = 0) : this(new Transform(x, y, w, h, r))
        {
        }

        public void GenerateAABB()
        {
            GenerateAABB(transform.size);
        }

        public void GenerateAABB(Vector2 size)
        {
            AABB = new BoxAABB()
            {
                min = -size * 0.5f,
                max = size * 0.5f,
            };
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void Render(PaintEventArgs e)
        {
            if (brush != null)
            {
                renderer.RenderShape(e, brush, transform, shape);
            }
            if (outlinePen != null)
            {
                renderer.RenderShape(e, outlinePen, transform, shape);
            }
        }

        public virtual void OnCollision(Collision collision)
        {
        }

        public virtual void OnTrigger(Collision collision)
        {
        }

        public static void Instantiate(GameObject gameObject)
        {
            GameState.Instance.gameLevel?.Add(gameObject);
        }

        public static void Instantiate(GameObject gameObject, GameObject parent)
        {
            gameObject.transform.parent = parent.transform;
            Instantiate(gameObject);
        }

        public void Destroy()
        {
            GameState.Instance.gameLevel?.Remove(this);
        }

        public virtual void Decorate() { }
    }
}
