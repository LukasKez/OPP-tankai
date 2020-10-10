using System;
using System.Windows.Forms;

namespace Client
{
    public abstract class GameObject
    {
        public Transform transform;

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

        public abstract void Update(float deltaTime);
        public abstract void Render(PaintEventArgs e);

        protected void Destroy()
        {
            GameState.Instance.gameLevel.Remove(this);
        }
    }
}
