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
    
    public abstract class GameObject
    {
        public Transform transform;
        public Shape shape;
        public Brush brush = Brushes.Magenta;

        protected GameObject()
        {
        }

        protected GameObject(Transform transform)
        {
            this.transform = transform;
        }

        protected GameObject(float x, float y, float w = 1, float h = 1, float r = 0)
        {
            transform.position.X = x;
            transform.position.Y = y;
            transform.size.X = w;
            transform.size.Y = h;
            transform.rotation = r;
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void Render(PaintEventArgs e)
        {
            switch (shape)
            {
                case Shape.None:
                    break;
                case Shape.Rectangle:
                    Renderer.Rectangle(e, brush, transform);
                    break;
                case Shape.Ellipse:
                    Renderer.Ellipse(e, brush, transform);
                    break;
                case Shape.Mesh:
                default:
                    throw new NotImplementedException("Shape not implemented");
            }
        }

        protected void Destroy()
        {
            GameState.Instance.gameLevel.Remove(this);
        }
    }
}
