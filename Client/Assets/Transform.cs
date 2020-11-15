using System;
using System.Collections.Generic;
using System.Numerics;

namespace Client
{
    public class Transform : IDisposable
    {
        public Transform parent;
        public List<Transform> childs;
        public GameObject gameObject;

        public float rotation;
        public float WorldRotation
        {
            get => rotation + (parent != null ? parent.WorldRotation : 0);
            set => rotation = value - (parent != null ? parent.WorldRotation : 0);
        }

        public Vector2 position;
        public Vector2 WorldPosition
        {
            get => position.Rotate(parent != null ? parent.WorldRotation : 0) + (parent != null ? parent.WorldPosition : Vector2.Zero);
            set => position = value.Rotate(parent != null ? parent.WorldRotation : 0) - (parent != null ? parent.WorldPosition : Vector2.Zero);
        }

        public Vector2 size;

        public Transform()
        {
            childs = new List<Transform>();
        }

        public Transform(float x = 0, float y = 0, float w = 1, float h = 1, float r = 0) : this()
        {
            position = new Vector2(x, y);
            size = new Vector2(w, h);
            rotation = r;
        }

        public Transform(Transform transform) : this()
        {
            position = new Vector2(transform.position.X, transform.position.Y);
            size = new Vector2(transform.size.X, transform.size.Y);
            rotation = transform.rotation;
            parent = transform.parent;
        }

        public void AddChild(Transform child)
        {
            childs.Add(child);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            GameState.Instance.gameLevel?.Remove(gameObject);
            foreach (Transform child in childs)
            {
                child.Dispose();
            }
        }
    }
}
