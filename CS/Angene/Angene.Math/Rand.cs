using Angene.Math.Interpolation;
using Angene.Math.Vectors;

namespace Angene.Math
{
    public static class Rand // Randomization, seed based.
    {
        private static Random _rng = new();
        public static void SetSeed(int seed) => _rng = new Random(seed);

        public static float Value => (float)_rng.NextDouble();
        public static float Range(float min, float max) => min + Value * (max - min);
        public static int Range(int min, int max) => _rng.Next(min, max);

        public static Vec2 InsideUnitCircle
        {
            get
            {
                // Rejection sampling — uniform distribution inside circle
                Vec2 v;
                do { v = new Vec2(Range(-1f, 1f), Range(-1f, 1f)); }
                while (v.LengthSquared > 1f);
                return v;
            }
        }

        public static Vec2 OnUnitCircle
        {
            get
            {
                float angle = Range(0f, Mathf.PI * 2f);
                return new Vec2(MathF.Cos(angle), MathF.Sin(angle));
            }
        }

        public static bool Chance(float probability) => Value < probability;

        public static T Pick<T>(IList<T> items)
        {
            if (items == null || items.Count == 0)
                throw new Main.AngeneException("Rand.Pick() called on null or empty list.");
            return items[Range(0, items.Count)];
        }

        public static void Shuffle<T>(IList<T> items)
        {
            if (items == null) return;
            for (int i = items.Count - 1; i > 0; i--)
            {
                int j = Range(0, i + 1);
                (items[i], items[j]) = (items[j], items[i]);
            }
        }
    }
}
