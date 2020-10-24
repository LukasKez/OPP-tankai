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

        public static Vector2 Rotate(this Vector2 vec, float angle)
        {
            Vector2 newVec;
            double radians = angle * Math.PI / 180;
            newVec.X = (float)(vec.X * Math.Cos(radians) - vec.Y * Math.Sin(radians));
            newVec.Y = (float)(vec.X * Math.Sin(radians) + vec.Y * Math.Cos(radians));
            return newVec;
        }

        public static Vector2 Substract(this Vector2 left, float right)
        {
            return new Vector2(left.X - right, left.Y - right);
        }
    }
}
