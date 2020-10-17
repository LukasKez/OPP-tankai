﻿using System;
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

        public Brush brush;
        protected Pen pen;

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
            if (brush != null)
            {
                Renderer.RenderShape(e, brush, transform, shape);
            }
            if (pen != null)
            {
                Renderer.RenderShape(e, pen, transform - pen.Width, shape);
            }
        }

        public static void Instantiate(GameObject gameObject)
        {
            GameState.Instance.gameLevel?.Add(gameObject);
        }

        public void Destroy()
        {
            GameState.Instance.gameLevel?.Remove(this);
        }
    }
}
