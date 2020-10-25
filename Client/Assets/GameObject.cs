using System;
using System.Drawing;
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
        public Transform transform;
        public Shape shape;
        public ColliderType collider;
        public bool isShadowCaster;
        private Renderer renderer = new Renderer();

        public Brush brush;
        protected Pen pen;

        public float damage;

        protected GameObject()
        {
            transform = new Transform();
        }

        protected GameObject(Transform transform)
        {
            this.transform = transform;
        }

        [Obsolete()]
        protected GameObject(float x, float y, float w = 1, float h = 1, float r = 0)
        {
            transform = new Transform(x, y, w, h, r);
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
            if (pen != null)
            {
                renderer.RenderShape(e, pen, transform, shape);
            }
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

        public virtual void Decorate(){ }
    }
}
