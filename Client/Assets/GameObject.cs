using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Client
{
    public abstract class GameObject
    {
        public struct Transform
        {
            public Vector position;
            public Vector size;
            public float rotation;
        }

        public Transform transform;

        protected GameObject(float x = 0, float y = 0, float w = 1, float h = 1, float r = 0)
        {
            transform.position.X = x;
            transform.position.Y = y;
            transform.size.X = w;
            transform.size.Y = h;
            transform.rotation = r;
        }

        public abstract void Update(float deltaTime);
        public abstract void Render(PaintEventArgs e);
    }
}
