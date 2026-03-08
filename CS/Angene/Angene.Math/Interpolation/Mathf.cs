using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Math.Interpolation
{
    // Being completely honest and truthful, most of this implementation was vibecoded, I have no idea how interpolation math works.
    public static class Mathf
    {
        public const float PI = MathF.PI;
        public const float Deg2Rad = MathF.PI / 180f;
        public const float Rad2Deg = 180f / MathF.PI;

        // Clamp / remap
        public static float Clamp(float v, float min, float max) => v < min ? min : v > max ? max : v;
        public static float Clamp01(float v) => Clamp(v, 0, 1);
        public static float Remap(float v, float inMin, float inMax, float outMin, float outMax) =>
                                Lerp(outMin, outMax, InverseLerp(inMin, inMax, v));
        public static float Lerp(float a, float b, float t) => a + (b - a) * Clamp01(t);
        public static float LerpUnclamped(float a, float b, float t) => a + (b - a) * t;
        public static float InverseLerp(float a, float b, float v) => (v - a) / (b - a);

        // Smoothing
        public static float SmoothStep(float a, float b, float t)
        {
            t = Clamp01((t - a) / (b - a));
            return t * t * (3 - 2 * t);
        }
        public static float SmootherStep(float a, float b, float t)
        {
            t = Clamp01((t - a) / (b - a));
            return t * t * t * (t * (t * 6 - 15) + 10);
        }
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            float diff = target - current;
            if (MathF.Abs(diff) <= maxDelta) return target;
            return current + MathF.Sign(diff) * maxDelta;
        }
        public static float SmoothDamp(float current, float target, ref float velocity,
                                        float smoothTime, double dt)
        {
            float omega = 2f / smoothTime;
            float x = omega * (float)dt;
            float exp = 1f / (1f + x + 0.48f * x * x + 0.235f * x * x * x);
            float change = current - target;
            float temp = (velocity + omega * change) * (float)dt;
            velocity = (velocity - omega * temp) * exp;
            return target + (change + temp) * exp;
        }

        // Angle helpers
        public static float DeltaAngle(float from, float to) // shortest arc in degrees
        {
            float delta = (to - from) % 360f;
            if (delta > 180f) delta -= 360f;
            if (delta < -180f) delta += 360f;
            return delta;
        }
        public static float LerpAngle(float a, float b, float t) =>
            a + DeltaAngle(a, b) * Clamp01(t); 

        // Easing — all take t in [0,1]
        public static class Ease
        {
            public static float InQuad(float t) => t * t;
            public static float OutQuad(float t) => 1 - (1 - t) * (1 - t);
            public static float InOutQuad(float t) => t < 0.5f ? 2 * t * t : 1 - MathF.Pow(-2 * t + 2, 2) / 2;
            public static float InCubic(float t) => t * t * t;
            public static float OutCubic(float t) => 1 - MathF.Pow(1 - t, 3);
            public static float InOutCubic(float t) => t < 0.5f ? 4 * t * t * t : 1 - MathF.Pow(-2 * t + 2, 3) / 2;
            public static float InBack(float t)
            {
                const float c = 1.70158f;
                return (c + 1) * t * t * t - c * t * t;
            }
            public static float InBounce(float t) => 1 - OutBounce(1 - t);
            public static float InElastic(float t)
            {
                if (t == 0) return 0;
                if (t == 1) return 1;
                return -MathF.Pow(2, 10 * t - 10) * MathF.Sin((t * 10 - 10.75f) * (2 * MathF.PI / 3));
            }
            public static float OutBack(float t)
            {
                const float c = 1.70158f;
                return 1 + (c + 1) * MathF.Pow(t - 1, 3) + c * MathF.Pow(t - 1, 2);
            }
            public static float OutBounce(float t)
            {
                const float n = 7.5625f, d = 2.75f;
                if (t < 1f / d) return n * t * t;
                if (t < 2 / d) return n * (t -= 1.5f / d) * t + 0.75f;
                if (t < 2.5f / d) return n * (t -= 2.25f / d) * t + 0.9375f;
                return n * (t -= 2.625f / d) * t + 0.984375f;
            }
            public static float OutElastic(float t)
            {
                if (t == 0) return 0;
                if (t == 1) return 1;
                return MathF.Pow(2, -10 * t) * MathF.Sin((t * 10 - 0.75f) * (2 * MathF.PI / 3)) + 1;
            }
        }
    }
}
