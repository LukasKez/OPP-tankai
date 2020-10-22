using System;

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
    }
}
