﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Client
{
    public abstract class TransformBase : IEnumerable<TransformBase>, IDisposable
    {
        public TransformBase parent;
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


        protected TransformBase(float x = 0, float y = 0, float w = 1, float h = 1, float r = 0)
        {
            position = new Vector2(x, y);
            size = new Vector2(w, h);
            rotation = r;
        }

        protected TransformBase(TransformBase transform)
        {
            position = new Vector2(transform.position.X, transform.position.Y);
            size = new Vector2(transform.size.X, transform.size.Y);
            rotation = transform.rotation;
            parent = transform.parent;
        }

        public virtual void AddChild(TransformBase child)
        {
        }

        public abstract IEnumerator<TransformBase> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }
}
