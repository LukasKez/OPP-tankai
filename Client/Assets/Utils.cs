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

        public static double Rad2deg(float radians)
        {
            return radians * 180 / Math.PI;
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

        public static Vector2 Reflect(this Vector2 inDirection, Vector2 inNormal)
        {
            float factor = -2F * Vector2.Dot(inNormal, inDirection);
            return new Vector2(factor * inNormal.X + inDirection.X, factor * inNormal.Y + inDirection.Y);
        }

        private const float kEpsilonNormalSqrt = 1e-15f;
        public static float Angle(this Vector2 from, Vector2 to)
        {
            // sqrt(a) * sqrt(b) = sqrt(a * b) -- valid for real numbers
            float denominator = (float)Math.Sqrt(from.LengthSquared() * to.LengthSquared());
            if (denominator < kEpsilonNormalSqrt)
                return 0F;

            float dot = Clamp(Vector2.Dot(from, to) / denominator, -1F, 1F);
            return (float)Rad2deg((float)Math.Acos(dot));
        }

        public static float SignedAngle(this Vector2 from, Vector2 to)
        {
            float unsigned_angle = Angle(from, to);
            float sign = Math.Sign(from.X * to.Y - from.Y * to.X);
            return unsigned_angle * sign;
        }

        public static Vector2 Substract(this Vector2 left, float right)
        {
            return new Vector2(left.X - right, left.Y - right);
        }

        public static double NextGaussian(this Random r, double mean = 0, double stdDev = 1)
        {
            double u1 = 1.0 - r.NextDouble();
            double u2 = 1.0 - r.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }
    }
}
