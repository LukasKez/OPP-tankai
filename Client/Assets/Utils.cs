using System;
using System.Numerics;

namespace Client
{
    public static class Utils
    {
        public static float Lerp(float value1, float value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }

        public static float LerpAngle(float value1, float value2, float amount)
        {
            float delta = Repeat((value2 - value1), 360);
            if (delta > 180)
                delta -= 360;
            return value1 + delta * amount;
        }

        public static float Repeat(float value, float length)
        {
            return Clamp(value - (float)Math.Floor(value / length) * length, 0f, length);
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        public static double Deg2rad(float degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static Vector2 Rotate(this Vector2 vec, float angle)
        {
            Vector2 newVec;
            double radians = Deg2rad(angle);
            newVec.X = (float)(vec.X * Math.Cos(radians) - vec.Y * Math.Sin(radians));
            newVec.Y = (float)(vec.X * Math.Sin(radians) + vec.Y * Math.Cos(radians));
            return newVec;
        }

        public static Vector2 Rotate(this Vector2 vec, float angle, Vector2 origin)
        {
            return (vec - origin).Rotate(angle) + origin;
        }

        public static Vector2 RotatedVector(float angle)
        {
            Vector2 vector;
            double radians = Deg2rad(angle);
            vector.X = (float)Math.Cos(radians);
            vector.Y = (float)Math.Sin(radians);
            return vector;
        }

        public static Vector2 RotatedVector(float angle, float length)
        {
            return RotatedVector(angle) * length;
        }

        public static Vector2 MoveTowards(this Vector2 current, Vector2 target, float maxDistanceDelta)
        {
            float toVector_x = target.X - current.X;
            float toVector_y = target.Y - current.Y;

            float sqDist = toVector_x * toVector_x + toVector_y * toVector_y;

            if (sqDist == 0 || (maxDistanceDelta >= 0 && sqDist <= maxDistanceDelta * maxDistanceDelta))
                return target;

            float dist = (float)Math.Sqrt(sqDist);

            return new Vector2(current.X + toVector_x / dist * maxDistanceDelta,
                current.Y + toVector_y / dist * maxDistanceDelta);
        }

        public static Vector2 Substract(this Vector2 left, float right)
        {
            return new Vector2(left.X - right, left.Y - right);
        }
    }
}
