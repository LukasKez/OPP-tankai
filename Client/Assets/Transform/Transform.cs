using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Client
{
    public class Transform : TransformBase
    {
        public List<TransformBase> children;

        public Transform()
        {
            children = new List<TransformBase>();
        }

        public Transform(float x = 0, float y = 0, float w = 1, float h = 1, float r = 0) : this()
        {
            position = new Vector2(x, y);
            size = new Vector2(w, h);
            rotation = r;
        }

        public Transform(TransformBase transform) : this()
        {
            position = new Vector2(transform.position.X, transform.position.Y);
            size = new Vector2(transform.size.X, transform.size.Y);
            rotation = transform.rotation;
            parent = transform.parent;
        }

        public override void AddChild(TransformBase child)
        {
            children.Add(child);
        }

        public override IEnumerator<TransformBase> GetEnumerator()
        {
            yield return this;
            foreach (TransformBase child in children)
            {
                foreach (TransformBase item in child)
                {
                    yield return item;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            GameState.Instance.gameLevel?.Remove(gameObject);
        }
    }
}
