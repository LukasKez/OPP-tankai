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
        public Shape shape;
        public ColliderType collider;
        public bool isStatic;
        public bool isShadowCaster;
        public float damage;

        private BoxAABB _AABB;
        public BoxAABB AABB
        {
            get => _AABB + transform.position;
            private set => _AABB = value;
        }

        private Transform _transform;
        public Transform transform
        {
            get
            {
                return _transform;
            }
            set
            {
                _transform = value;
                _transform.gameObject = this;
            }
        }

        public Brush brush;
        public Pen outlinePen;

        private Renderer renderer;

        protected GameObject() : this(new Transform())
        {
        }

        protected GameObject(Transform transform)
        {
            this.transform = transform;
            renderer = new Renderer();
            GenerateAABB();
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
            if (gameObject != parent)
            {
                parent.transform.AddChild(gameObject.transform);
                gameObject.transform.parent = parent.transform;
            }

            Instantiate(gameObject);
        }

        public void Destroy()
        {
            transform.Dispose();
        }

        public virtual void Decorate() { }
    }
}
