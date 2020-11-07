using System;
using System.Collections.Generic;
using System.Numerics;

namespace Client
{
    public struct BoxAABB
    {
        public Vector2 min;
        public Vector2 max;

        public static BoxAABB operator +(BoxAABB a, Vector2 b)
        {
            return new BoxAABB() { min = a.min + b, max = a.max + b, };
        }
    }

    public struct Collision
    {
        public GameObject other;
        public Vector2 penetration;
        public Vector2 normal;
    }

    static class Physics
    {
        public static void HandleCollisions(IEnumerable<GameObject> stuff)
        {
            foreach (var item1 in stuff)
            {
                if (item1.isStatic)
                    continue;

                if (item1.collider == ColliderType.None)
                    continue;

                foreach (var item2 in stuff)
                {

                    if (item2.collider == ColliderType.None)
                        continue;

                    if (item1 == item2)
                        continue;

                    Collision collision = default;
                    if (item1.shape == Shape.Ellipse && item2.shape == Shape.Ellipse)
                    {
                        if (!CirclevsCircleOverlap(item1, item2, ref collision))
                            continue;
                    }
                    else if (item2.shape == Shape.Ellipse)
                    {
                        if (!AABBvsCircleOverlap(item1, item2, ref collision))
                            continue;
                    }
                    else if (item1.shape == Shape.Ellipse)
                    {

                        if (!AABBvsCircleOverlap(item2, item1, ref collision))
                            continue;
                        collision.normal = -collision.normal;
                    }
                    else
                    {
                        if (!AABBvsAABBOverlap(item1, item2, ref collision))
                            continue;
                    }

                    InvokeCallback(item1, item2, collision);
                    InvokeCallback(item2, item1, collision);

                    if (item1.collider == ColliderType.Trigger)
                        continue;

                    if (item2.collider == ColliderType.Trigger)
                        continue;

                    if (item2.isStatic)
                    {
                        ResolveCollision(item1, item2, collision, false);
                        continue;
                    }

                    ResolveCollision(item1, item2, collision, true);
                }
            }
        }

        private static void InvokeCallback(GameObject item1, GameObject item2, Collision collision)
        {
            collision.other = item2;
            switch (item2.collider)
            {
                case ColliderType.Collider:
                    item1.OnCollision(collision);
                    break;
                case ColliderType.Trigger:
                    item1.OnTrigger(collision);
                    break;
            }
        }

        private static bool AABBvsAABBOverlap(GameObject item1, GameObject item2, ref Collision collision)
        {
            float eps = 1e-3f;

            BoxAABB rect1 = item1.AABB;
            BoxAABB rect2 = item2.AABB;

            if (rect1.max.X <= rect2.min.X || rect1.min.X >= rect2.max.X ||
                rect1.max.Y <= rect2.min.Y || rect1.min.Y >= rect2.max.Y)
                return false;

            bool biasX = item1.transform.position.X < item2.transform.position.X;
            bool biasY = item1.transform.position.Y < item2.transform.position.Y;

            float penX = biasX ? (rect1.max.X - rect2.min.X) : (rect2.max.X - rect1.min.X);
            float penY = biasY ? (rect1.max.Y - rect2.min.Y) : (rect2.max.Y - rect1.min.Y);
            float diff = penX - penY;

            collision.penetration = new Vector2(penX, penY);

            if (diff > eps)
            {
                collision.normal = new Vector2(0, biasY ? 1 : -1);
                return true;
            }

            if (diff < -eps)
            {
                collision.normal = new Vector2(biasX ? 1 : -1, 0);
                return true;
            }

            collision.normal = new Vector2(biasX ? 1 : -1, biasY ? 1 : -1);
            return true;
        }

        private static bool CirclevsCircleOverlap(GameObject item1, GameObject item2, ref Collision collision)
        {
            Transform circle1 = item1.transform;
            Transform circle2 = item2.transform;

            float radius = (Math.Max(circle1.size.X, circle1.size.Y) + Math.Max(circle2.size.X, circle2.size.Y)) / 2;
            Vector2 normal = circle2.position - circle1.position;

            if (radius * radius <= normal.LengthSquared())
                return false;

            float normalLen = normal.Length();
            float pen = radius - normalLen;

            collision.penetration = new Vector2(pen);
            collision.normal = normal / normalLen;

            return true;
        }

        private static bool AABBvsCircleOverlap(GameObject item1, GameObject item2, ref Collision collision)
        {
            float eps = 1e-3f;

            BoxAABB rect = item1.AABB;
            Transform rectTr = item1.transform;
            Transform circle = item2.transform;

            if (rectTr.position == circle.position)
                return false;

            float radius = Math.Max(circle.size.X, circle.size.Y) / 2f;
            Vector2 closest = Vector2.Clamp(circle.position, rect.min, rect.max);

            if (closest == circle.position)
                closest = circle.position.MoveTowards(rectTr.position, eps);

            Vector2 normal = circle.position - closest;

            if (radius * radius <= normal.LengthSquared())
                return false;

            float normalLen = normal.Length();
            float pen = radius - normalLen;

            collision.penetration = new Vector2(pen);
            collision.normal = normal / normalLen;

            return true;
        }

        private static void ResolveCollision(GameObject item1, GameObject item2, Collision collision, bool equaly = false)
        {
            Transform tr1 = item1.transform;
            Transform tr2 = item2.transform;

            Vector2 correction = collision.normal * collision.penetration;

            if (equaly)
            {
                correction /= 2f;
                tr2.position += correction;
            }
            tr1.position -= correction;
        }
    }
}
