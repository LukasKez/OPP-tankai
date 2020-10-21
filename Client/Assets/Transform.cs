using System;
using System.Numerics;

namespace Client
{
    public struct Transform
    {
        public float rotation { get; set; }
        public Vector2 position;
        public Vector2 size;

        public Transform(float x, float y, float w = 1, float h = 1, float r = 0)
        {
            position = new Vector2(x, y);
            size = new Vector2(w, h);
            rotation = r;
        }

        public static Transform operator -(Transform left, float right)
        {
            float half = right / 2;
            left.position.X += half;
            left.position.Y += half;
            left.size.X -= right;
            left.size.Y -= right;
            return left;
        }
    }
}
