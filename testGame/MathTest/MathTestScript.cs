using Angene.Common;
using Angene.Essentials;
using Angene.Math;
using Angene.Math.GPU;
using Angene.Math.Interpolation;
using Angene.Math.Vectors;
using Angene.Windows;
using System;
using System.Linq;

namespace Game
{
    /// <summary>
    /// Phase-based test script for Angene.Math.
    ///
    ///   Phase 0  — Vec2 operations
    ///   Phase 1  — Vec3 operations
    ///   Phase 2  — Matrix3x3 operations
    ///   Phase 3  — Rect
    ///   Phase 4  — CPU interpolation (Mathf + easing)
    ///   Phase 5  — Randomisation (Rand)
    ///   Phase 6  — GpuMath CPU-fallback path (bulk Vec2)
    ///   Phase 7  — GpuMath CPU-fallback path (bulk Vec3 + scalars)
    ///   Phase 8  — GpuMath CPU-fallback path (reductions)
    ///   Phase 9  — Done / self-close
    ///
    /// All GpuMath arrays are sized well below the default threshold (512) so
    /// the CPU fallback runs.  NullComputeBackend throws loudly if a real
    /// GPU dispatch is ever attempted, so a size mistake won't silently corrupt.
    /// </summary>
    internal class MathTestScript : IScreenPlay
    {
        private double _elapsed;
        private int _phase = 0;

        // How many seconds to wait before advancing each phase.
        private static readonly double[] PhaseAt = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private Angene.Math.GPU.Math? _gpu;
        private float _smoothDampVelocity = 0f;

        // ── Lifecycle ────────────────────────────────────────────────────────

        public void Start()
        {
            Logger.LogInfo("MathTestScript: Start() — Angene.Math demo beginning.", LoggingTarget.MainGame);
            Logger.LogInfo("MathTestScript: Phases 0-8 run at 1-second intervals; ESC closes early.", LoggingTarget.MainGame);

            // Construct GpuMath with the stub backend.
            // Real GPU work would require a D3D11/Vulkan IComputeBackend here.
            _gpu = new Angene.Math.GPU.Math(new NullComputeBackend());
        }

        public void Update(double dt)
        {
            _elapsed += dt;

            switch (_phase)
            {
                case 0 when _elapsed >= PhaseAt[0]:
                    RunVec2Tests();
                    _phase++;
                    break;

                case 1 when _elapsed >= PhaseAt[1]:
                    RunVec3Tests();
                    _phase++;
                    break;

                case 2 when _elapsed >= PhaseAt[2]:
                    RunMatrix3x3Tests();
                    _phase++;
                    break;

                case 3 when _elapsed >= PhaseAt[3]:
                    RunRectTests();
                    _phase++;
                    break;

                case 4 when _elapsed >= PhaseAt[4]:
                    RunInterpolationTests();
                    _phase++;
                    break;

                case 5 when _elapsed >= PhaseAt[5]:
                    RunRandTests();
                    _phase++;
                    break;

                case 6 when _elapsed >= PhaseAt[6]:
                    RunGpuMathVec2Tests();
                    _phase++;
                    break;

                case 7 when _elapsed >= PhaseAt[7]:
                    RunGpuMathVec3AndScalarTests();
                    _phase++;
                    break;

                case 8 when _elapsed >= PhaseAt[8]:
                    RunGpuMathReductionTests();
                    _phase++;
                    break;

                case 9 when _elapsed >= PhaseAt[9]:
                    Logger.LogInfo(
                        $"[t={_elapsed:F1}s] All Angene.Math tests complete. Requesting close.",
                        LoggingTarget.MainGame);
                    _phase++;

#if WINDOWS
                    Win32.PostQuitMessage(0);
#endif
                    break;
            }
        }

        // ── Phase 0 — Vec2 ───────────────────────────────────────────────────

        private void RunVec2Tests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 0: Vec2 ──", LoggingTarget.MainGame);

            var a = new Vec2(3f, 4f);
            var b = new Vec2(1f, 2f);

            Logger.LogInfo($"  a = ({a.X}, {a.Y})", LoggingTarget.MainGame);
            Logger.LogInfo($"  b = ({b.X}, {b.Y})", LoggingTarget.MainGame);

            var sum = a + b;
            var diff = a - b;
            var scaled = a * 2f;
            var divided = a / 2f;
            Logger.LogInfo($"  a + b         = ({sum.X}, {sum.Y})", LoggingTarget.MainGame);
            Logger.LogInfo($"  a - b         = ({diff.X}, {diff.Y})", LoggingTarget.MainGame);
            Logger.LogInfo($"  a * 2         = ({scaled.X}, {scaled.Y})", LoggingTarget.MainGame);
            Logger.LogInfo($"  a / 2         = ({divided.X}, {divided.Y})", LoggingTarget.MainGame);

            float len = a.Length;       // expected: 5
            float lenSq = a.LengthSquared; // expected: 25
            var norm = a.Normalized;
            float dot = Vec2.Dot(a, b); // 3+8 = 11
            float dist = Vec2.Distance(a, b);
            var lerped = Vec2.Lerp(a, b, 0.5f);
            var normal = Vec2.Up;
            var reflected = Vec2.Reflect(a, normal);

            Logger.LogInfo($"  |a|           = {len:F4}  (expected 5)", LoggingTarget.MainGame);
            Logger.LogInfo($"  |a|²          = {lenSq:F4}  (expected 25)", LoggingTarget.MainGame);
            Logger.LogInfo($"  a.Normalized  = ({norm.X:F4}, {norm.Y:F4})", LoggingTarget.MainGame);
            Logger.LogInfo($"  Dot(a,b)      = {dot:F4}  (expected 11)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Distance(a,b) = {dist:F4}", LoggingTarget.MainGame);
            Logger.LogInfo($"  Lerp(a,b,0.5) = ({lerped.X:F4}, {lerped.Y:F4})", LoggingTarget.MainGame);
            Logger.LogInfo($"  Reflect(a,Up) = ({reflected.X:F4}, {reflected.Y:F4})", LoggingTarget.MainGame);

            // Static constants
            Logger.LogInfo($"  Vec2.Zero  = ({Vec2.Zero.X}, {Vec2.Zero.Y})", LoggingTarget.MainGame);
            Logger.LogInfo($"  Vec2.One   = ({Vec2.One.X}, {Vec2.One.Y})", LoggingTarget.MainGame);
            Logger.LogInfo($"  Vec2.Up    = ({Vec2.Up.X}, {Vec2.Up.Y})  [screen space — y-up is -1]", LoggingTarget.MainGame);
            Logger.LogInfo($"  Vec2.Right = ({Vec2.Right.X}, {Vec2.Right.Y})", LoggingTarget.MainGame);

            Assert(MathF.Abs(len - 5f) < 1e-4f, "Vec2 length");
            Assert(MathF.Abs(dot - 11f) < 1e-4f, "Vec2 dot");
            Logger.LogInfo("  Phase 0 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 1 — Vec3 ───────────────────────────────────────────────────

        private void RunVec3Tests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 1: Vec3 ──", LoggingTarget.MainGame);

            var a = new Vec3(1f, 0f, 0f); // X unit
            var b = new Vec3(0f, 1f, 0f); // Y unit

            var cross = Vec3.Cross(a, b);  // should be (0, 0, 1) — Z unit
            float dot = Vec3.Dot(a, b);    // perpendicular → 0

            Logger.LogInfo($"  a             = ({a.X}, {a.Y}, {a.Z})", LoggingTarget.MainGame);
            Logger.LogInfo($"  b             = ({b.X}, {b.Y}, {b.Z})", LoggingTarget.MainGame);
            Logger.LogInfo($"  Cross(a,b)    = ({cross.X:F4}, {cross.Y:F4}, {cross.Z:F4})  (expected 0,0,1)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Dot(a,b)      = {dot:F4}  (expected 0)", LoggingTarget.MainGame);

            var v = new Vec3(3f, 4f, 0f);
            float len = v.Length; // 5
            var norm = v.Normalized;
            var lerped = Vec3.Lerp(a, b, 0.5f);
            var sum = a + b;
            var scaled = v * 3f;

            Logger.LogInfo($"  v             = ({v.X}, {v.Y}, {v.Z})", LoggingTarget.MainGame);
            Logger.LogInfo($"  |v|           = {len:F4}  (expected 5)", LoggingTarget.MainGame);
            Logger.LogInfo($"  v.Normalized  = ({norm.X:F4}, {norm.Y:F4}, {norm.Z:F4})", LoggingTarget.MainGame);
            Logger.LogInfo($"  Lerp(a,b,0.5) = ({lerped.X:F4}, {lerped.Y:F4}, {lerped.Z:F4})", LoggingTarget.MainGame);
            Logger.LogInfo($"  a + b         = ({sum.X}, {sum.Y}, {sum.Z})", LoggingTarget.MainGame);
            Logger.LogInfo($"  v * 3         = ({scaled.X}, {scaled.Y}, {scaled.Z})", LoggingTarget.MainGame);

            Assert(MathF.Abs(cross.Z - 1f) < 1e-4f, "Vec3 cross Z");
            Assert(MathF.Abs(dot) < 1e-4f, "Vec3 dot perpendicular");
            Assert(MathF.Abs(len - 5f) < 1e-4f, "Vec3 length");
            Logger.LogInfo("  Phase 1 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 2 — Matrix3x3 ──────────────────────────────────────────────

        private void RunMatrix3x3Tests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 2: Matrix3x3 ──", LoggingTarget.MainGame);

            // Identity * point = same point
            var identity = Matrix3x3.Identity;
            var pt = new Vec2(5f, 3f);
            var identityPt = identity * pt;
            Logger.LogInfo($"  Identity * (5,3)         = ({identityPt.X:F4}, {identityPt.Y:F4})  (expected 5,3)", LoggingTarget.MainGame);

            // Translation
            var translate = Matrix3x3.Translation(10f, 20f);
            var translated = translate * pt;
            Logger.LogInfo($"  Translate(10,20) * (5,3) = ({translated.X:F4}, {translated.Y:F4})  (expected 15,23)", LoggingTarget.MainGame);

            // Scale
            var scale = Matrix3x3.Scale(2f, 3f);
            var scaledPt = scale * pt;
            Logger.LogInfo($"  Scale(2,3) * (5,3)       = ({scaledPt.X:F4}, {scaledPt.Y:F4})  (expected 10,9)", LoggingTarget.MainGame);

            // Rotation by 90° (π/2) — (1,0) should become (0,1) in standard math coords
            var rot90 = Matrix3x3.Rotation(MathF.PI / 2f);
            var unitX = new Vec2(1f, 0f);
            var rotated = rot90 * unitX;
            Logger.LogInfo($"  Rotate90 * (1,0)         = ({rotated.X:F4}, {rotated.Y:F4})  (expected ~0,1)", LoggingTarget.MainGame);

            // Matrix multiply: T * S should translate then scale — test composition
            var ts = translate * scale;
            var tsPt = ts * pt;
            Logger.LogInfo($"  (Translate*Scale) * (5,3)= ({tsPt.X:F4}, {tsPt.Y:F4})", LoggingTarget.MainGame);

            Assert(MathF.Abs(identityPt.X - 5f) < 1e-4f && MathF.Abs(identityPt.Y - 3f) < 1e-4f, "Identity transform");
            Assert(MathF.Abs(translated.X - 15f) < 1e-4f && MathF.Abs(translated.Y - 23f) < 1e-4f, "Translation");
            Assert(MathF.Abs(scaledPt.X - 10f) < 1e-4f && MathF.Abs(scaledPt.Y - 9f) < 1e-4f, "Scale");
            Assert(MathF.Abs(rotated.Y - 1f) < 1e-3f, "Rotation 90 deg");
            Logger.LogInfo("  Phase 2 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 3 — Rect ───────────────────────────────────────────────────

        private void RunRectTests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 3: Rect ──", LoggingTarget.MainGame);

            var r = new Rect(10f, 10f, 100f, 50f);
            Logger.LogInfo($"  Rect: x={r.X} y={r.Y} w={r.Width} h={r.Height}", LoggingTarget.MainGame);
            Logger.LogInfo($"  Edges: L={r.Left} R={r.Right} T={r.Top} B={r.Bottom}", LoggingTarget.MainGame);
            Logger.LogInfo($"  Center: ({r.Center.X}, {r.Center.Y})  (expected 60, 35)", LoggingTarget.MainGame);

            var inside = new Vec2(50f, 30f);
            var outside = new Vec2(5f, 5f);
            Logger.LogInfo($"  Contains({inside.X},{inside.Y})  = {r.Contains(inside)}   (expected True)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Contains({outside.X},{outside.Y}) = {r.Contains(outside)}  (expected False)", LoggingTarget.MainGame);

            var r2 = new Rect(80f, 40f, 60f, 30f); // overlaps r
            var r3 = new Rect(200f, 200f, 20f, 20f); // no overlap
            Logger.LogInfo($"  Intersects(overlapping) = {r.Intersects(r2)}  (expected True)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Intersects(separate)    = {r.Intersects(r3)}  (expected False)", LoggingTarget.MainGame);

            var expanded = r.Expand(5f);
            Logger.LogInfo($"  Expand(5): x={expanded.X} y={expanded.Y} w={expanded.Width} h={expanded.Height}  (expected 5,5,110,60)", LoggingTarget.MainGame);

            Assert(r.Contains(inside), "Rect.Contains inside");
            Assert(!r.Contains(outside), "Rect.Contains outside");
            Assert(r.Intersects(r2), "Rect.Intersects overlapping");
            Assert(!r.Intersects(r3), "Rect.Intersects separate");
            Logger.LogInfo("  Phase 3 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 4 — Interpolation ──────────────────────────────────────────

        private void RunInterpolationTests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 4: Interpolation (Mathf) ──", LoggingTarget.MainGame);

            // Clamp / Remap
            Logger.LogInfo("  -- Clamp / Remap --", LoggingTarget.MainGame);
            Logger.LogInfo($"  Clamp(5, 0, 3)        = {Mathf.Clamp(5f, 0f, 3f)}  (expected 3)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Clamp01(-0.5)         = {Mathf.Clamp01(-0.5f)}  (expected 0)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Remap(5, 0,10, 0,100) = {Mathf.Remap(5f, 0f, 10f, 0f, 100f)}  (expected 50)", LoggingTarget.MainGame);
            Logger.LogInfo($"  InverseLerp(0,10,5)   = {Mathf.InverseLerp(0f, 10f, 5f):F4}  (expected 0.5)", LoggingTarget.MainGame);

            // Lerp
            Logger.LogInfo("  -- Lerp --", LoggingTarget.MainGame);
            Logger.LogInfo($"  Lerp(0, 100, 0.25)    = {Mathf.Lerp(0f, 100f, 0.25f)}  (expected 25)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Lerp(0, 100, 1.5)     = {Mathf.Lerp(0f, 100f, 1.5f)}   (clamped to 100)", LoggingTarget.MainGame);
            Logger.LogInfo($"  LerpUnclamped(0,100,1.5) = {Mathf.LerpUnclamped(0f, 100f, 1.5f)}  (unclamped: 150)", LoggingTarget.MainGame);

            // Smoothing
            Logger.LogInfo("  -- Smoothing --", LoggingTarget.MainGame);
            Logger.LogInfo($"  SmoothStep(0,1,0.5)   = {Mathf.SmoothStep(0f, 1f, 0.5f):F4}  (expected 0.5)", LoggingTarget.MainGame);
            Logger.LogInfo($"  SmootherStep(0,1,0.5) = {Mathf.SmootherStep(0f, 1f, 0.5f):F4}  (expected 0.5)", LoggingTarget.MainGame);
            Logger.LogInfo($"  MoveTowards(0,10,3)   = {Mathf.MoveTowards(0f, 10f, 3f)}  (expected 3)", LoggingTarget.MainGame);
            Logger.LogInfo($"  MoveTowards(9,10,3)   = {Mathf.MoveTowards(9f, 10f, 3f)}  (clamped to 10)", LoggingTarget.MainGame);

            float vel = _smoothDampVelocity;
            float damped = Mathf.SmoothDamp(0f, 100f, ref vel, smoothTime: 0.5f, dt: 0.016);
            Logger.LogInfo($"  SmoothDamp(0→100, dt=16ms) = {damped:F4}  (small step toward target)", LoggingTarget.MainGame);
            _smoothDampVelocity = vel;

            // Angle helpers
            Logger.LogInfo("  -- Angle helpers --", LoggingTarget.MainGame);
            Logger.LogInfo($"  DeltaAngle(10, 350)   = {Mathf.DeltaAngle(10f, 350f):F4}  (expected -20 — shortest arc)", LoggingTarget.MainGame);
            Logger.LogInfo($"  LerpAngle(0, 90, 0.5) = {Mathf.LerpAngle(0f, 90f, 0.5f):F4}  (expected 45)", LoggingTarget.MainGame);

            // Easing — sample each at t=0, 0.5, 1
            Logger.LogInfo("  -- Easing (t=0 / 0.5 / 1) --", LoggingTarget.MainGame);
            LogEase("InQuad", Mathf.Ease.InQuad);
            LogEase("OutQuad", Mathf.Ease.OutQuad);
            LogEase("InOutQuad", Mathf.Ease.InOutQuad);
            LogEase("InCubic", Mathf.Ease.InCubic);
            LogEase("OutCubic", Mathf.Ease.OutCubic);
            LogEase("InOutCubic", Mathf.Ease.InOutCubic);
            LogEase("InBack", Mathf.Ease.InBack);
            LogEase("OutBack", Mathf.Ease.OutBack);
            LogEase("InElastic", Mathf.Ease.InElastic);
            LogEase("OutElastic", Mathf.Ease.OutElastic);
            LogEase("InBounce", Mathf.Ease.InBounce);
            LogEase("OutBounce", Mathf.Ease.OutBounce);

            Logger.LogInfo("  Phase 4 OK.", LoggingTarget.MainGame);
        }

        private void LogEase(string name, Func<float, float> fn)
        {
            Logger.LogInfo(
                $"  {name,-14} t=0:{fn(0f):F4}  t=0.5:{fn(0.5f):F4}  t=1:{fn(1f):F4}",
                LoggingTarget.MainGame);
        }

        // ── Phase 5 — Rand ───────────────────────────────────────────────────

        private void RunRandTests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 5: Rand ──", LoggingTarget.MainGame);

            // Seed for determinism
            Rand.SetSeed(42);
            Logger.LogInfo("  Seed set to 42 — results below are reproducible.", LoggingTarget.MainGame);

            // Value
            float v1 = Rand.Value;
            float v2 = Rand.Value;
            Logger.LogInfo($"  Value × 2 : {v1:F6}, {v2:F6}  (in [0,1))", LoggingTarget.MainGame);

            // Float range
            float fr = Rand.Range(-5f, 5f);
            Logger.LogInfo($"  Range(-5, 5) : {fr:F4}", LoggingTarget.MainGame);

            // Int range
            int ir = Rand.Range(0, 10);
            Logger.LogInfo($"  Range(0, 10) : {ir}  (in [0,10))", LoggingTarget.MainGame);

            // InsideUnitCircle — should have length ≤ 1
            var circle = Rand.InsideUnitCircle;
            Logger.LogInfo($"  InsideUnitCircle : ({circle.X:F4}, {circle.Y:F4})  |v|={circle.Length:F4}  (≤ 1)", LoggingTarget.MainGame);

            // OnUnitCircle — should have length ≈ 1
            var onCircle = Rand.OnUnitCircle;
            Logger.LogInfo($"  OnUnitCircle     : ({onCircle.X:F4}, {onCircle.Y:F4})  |v|={onCircle.Length:F4}  (≈ 1)", LoggingTarget.MainGame);

            // Chance
            Rand.SetSeed(0);
            int trueCount = 0;
            for (int i = 0; i < 1000; i++)
                if (Rand.Chance(0.3f)) trueCount++;
            Logger.LogInfo($"  Chance(0.3) over 1000 trials : {trueCount} trues  (expected ~300)", LoggingTarget.MainGame);

            // Pick
            var items = new[] { "alpha", "beta", "gamma", "delta" };
            Rand.SetSeed(99);
            string picked = Rand.Pick(items);
            Logger.LogInfo($"  Pick([alpha,beta,gamma,delta]) : \"{picked}\"", LoggingTarget.MainGame);

            // Shuffle
            var list = new System.Collections.Generic.List<int> { 1, 2, 3, 4, 5 };
            Rand.SetSeed(7);
            Rand.Shuffle(list);
            Logger.LogInfo($"  Shuffle([1..5]) : [{string.Join(", ", list)}]", LoggingTarget.MainGame);

            Assert(circle.Length <= 1f + 1e-4f, "InsideUnitCircle length ≤ 1");
            Assert(MathF.Abs(onCircle.Length - 1f) < 1e-4f, "OnUnitCircle length ≈ 1");
            Assert(trueCount > 200 && trueCount < 400, "Chance distribution within 200-400 / 1000");
            Logger.LogInfo("  Phase 5 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 6 — GpuMath: Vec2 bulk (CPU fallback) ──────────────────────

        private void RunGpuMathVec2Tests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 6: GpuMath Vec2 (CPU fallback) ──", LoggingTarget.MainGame);
            Logger.LogInfo("  Arrays are 8 elements — below GpuThreshold=512, so CPU path runs.", LoggingTarget.MainGame);

            if (_gpu == null) { Logger.LogError("  GpuMath not initialised — skipping.", LoggingTarget.MainGame); return; }

            var a = Enumerable.Range(0, 8).Select(i => new Vec2(i, i * 2f)).ToArray();
            var b = Enumerable.Range(0, 8).Select(i => new Vec2(1f, 1f)).ToArray();

            // Add
            var added = _gpu.Add(a, b);
            Logger.LogInfo($"  Add [0..7] + (1,1) : first=({added[0].X},{added[0].Y}) last=({added[7].X},{added[7].Y})", LoggingTarget.MainGame);

            // Scale
            var scaled = _gpu.Scale(a, 2f);
            Logger.LogInfo($"  Scale [0..7] × 2   : first=({scaled[0].X},{scaled[0].Y}) last=({scaled[7].X},{scaled[7].Y})", LoggingTarget.MainGame);

            // Normalize
            var normed = _gpu.Normalize(a[1..]);  // skip (0,0) which would be NaN
            Logger.LogInfo($"  Normalize[1..7][0] = ({normed[0].X:F4},{normed[0].Y:F4})  |v|≈{normed[0].Length:F4}", LoggingTarget.MainGame);

            // Dot
            var dots = _gpu.Dot(a, b);
            Logger.LogInfo($"  Dot [0..7],(1,1)   : first={dots[0]:F4} (0*1+0*1=0), [1]={dots[1]:F4} (1+2=3)", LoggingTarget.MainGame);

            // Length
            var lengths = _gpu.Length(a);
            Logger.LogInfo($"  Length [0..7]      : [0]={lengths[0]:F4} [3]={lengths[3]:F4} (expected {new Vec2(3, 6).Length:F4})", LoggingTarget.MainGame);

            // Lerp (uniform t)
            var lerped = _gpu.Lerp(a, b, 0.5f);
            Logger.LogInfo($"  Lerp(a,b,0.5)[1]   = ({lerped[1].X:F4},{lerped[1].Y:F4})  (expected 1,1.5)", LoggingTarget.MainGame);

            // Lerp (per-element t)
            var ts = Enumerable.Range(0, 8).Select(i => i / 7f).ToArray();
            var lerpedPer = _gpu.Lerp(a, b, ts);
            Logger.LogInfo($"  Lerp(a,b,t[])[4]   = ({lerpedPer[4].X:F4},{lerpedPer[4].Y:F4})", LoggingTarget.MainGame);

            Assert(MathF.Abs(added[1].X - 2f) < 1e-4f, "GpuMath Vec2 Add");
            Assert(MathF.Abs(dots[1] - 3f) < 1e-4f, "GpuMath Vec2 Dot");
            Logger.LogInfo("  Phase 6 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 7 — GpuMath: Vec3 + scalars (CPU fallback) ─────────────────

        private void RunGpuMathVec3AndScalarTests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 7: GpuMath Vec3 + Scalars (CPU fallback) ──", LoggingTarget.MainGame);

            if (_gpu == null) { Logger.LogError("  GpuMath not initialised — skipping.", LoggingTarget.MainGame); return; }

            // Vec3 bulk ops
            var v3a = Enumerable.Range(1, 8).Select(i => new Vec3(i, 0f, 0f)).ToArray(); // X-axis vectors
            var v3b = Enumerable.Range(1, 8).Select(i => new Vec3(0f, i, 0f)).ToArray(); // Y-axis vectors

            var v3Added = _gpu.Add(v3a, v3b);
            Logger.LogInfo($"  Vec3 Add[0] = ({v3Added[0].X},{v3Added[0].Y},{v3Added[0].Z})  (expected 1,1,0)", LoggingTarget.MainGame);

            var crosses = _gpu.Cross(v3a, v3b); // X × Y = Z
            Logger.LogInfo($"  Vec3 Cross[0] = ({crosses[0].X:F4},{crosses[0].Y:F4},{crosses[0].Z:F4})  (expected 0,0,1)", LoggingTarget.MainGame);

            var v3Normed = _gpu.Normalize(v3a);
            Logger.LogInfo($"  Vec3 Normalize[0] = ({v3Normed[0].X:F4},{v3Normed[0].Y:F4},{v3Normed[0].Z:F4})", LoggingTarget.MainGame);

            var v3Dots = _gpu.Dot(v3a, v3b);
            Logger.LogInfo($"  Vec3 Dot(X,Y)[0] = {v3Dots[0]:F4}  (expected 0 — perpendicular)", LoggingTarget.MainGame);

            // Scalar bulk ops
            var values = Enumerable.Range(0, 8).Select(i => (float)i * 10f).ToArray(); // 0,10,20..70

            var clamped = _gpu.Clamp(values, 15f, 55f);
            Logger.LogInfo($"  Clamp([0..70], 15, 55): [{string.Join(", ", clamped.Select(v => $"{v:F0}"))}]", LoggingTarget.MainGame);

            var fLerped = _gpu.Lerp(values, Enumerable.Repeat(100f, 8).ToArray(), 0.5f);
            Logger.LogInfo($"  Lerp(vals, 100, 0.5)[0] = {fLerped[0]:F4}  (expected 50)", LoggingTarget.MainGame);

            var remapped = _gpu.Remap(values, 0f, 70f, 0f, 1f);
            Logger.LogInfo($"  Remap([0..70], 0,70→0,1): [{string.Join(", ", remapped.Select(v => $"{v:F2}"))}]", LoggingTarget.MainGame);

            var sqrts = _gpu.Sqrt(new[] { 0f, 1f, 4f, 9f, 16f, 25f, 36f, 49f });
            Logger.LogInfo($"  Sqrt([0²..7²]) = [{string.Join(", ", sqrts.Select(v => $"{v:F1}"))}]", LoggingTarget.MainGame);

            var absd = _gpu.Abs(new[] { -3f, -2f, -1f, 0f, 1f, 2f, 3f, 4f });
            Logger.LogInfo($"  Abs([-3..4])   = [{string.Join(", ", absd.Select(v => $"{v:F0}"))}]", LoggingTarget.MainGame);

            // Matrix GPU ops
            var mats = Enumerable.Repeat(Matrix3x3.Identity, 8).ToArray();
            var pt = Enumerable.Repeat(new Vec2(5f, 3f), 8).ToArray();
            var transformed = _gpu.Transform(Matrix3x3.Translation(2f, 4f), pt);
            Logger.LogInfo($"  Matrix Transform (Identity+T(2,4)) * (5,3)[0] = ({transformed[0].X},{transformed[0].Y})  (expected 7,7)", LoggingTarget.MainGame);

            var matMul = _gpu.Multiply(mats, mats); // I*I = I
            Logger.LogInfo($"  Matrix Multiply (I*I)[0].M00 = {matMul[0].M00}  (expected 1)", LoggingTarget.MainGame);

            Assert(MathF.Abs(crosses[0].Z - 1f) < 1e-4f, "GpuMath Vec3 Cross Z");
            Assert(MathF.Abs(clamped[0] - 15f) < 1e-4f, "GpuMath Scalar Clamp low");
            Assert(MathF.Abs(clamped[7] - 55f) < 1e-4f, "GpuMath Scalar Clamp high");
            Assert(MathF.Abs(sqrts[4] - 4f) < 1e-4f, "GpuMath Sqrt");
            Logger.LogInfo("  Phase 7 OK.", LoggingTarget.MainGame);
        }

        // ── Phase 8 — GpuMath: Reductions (CPU fallback) ─────────────────────

        private void RunGpuMathReductionTests()
        {
            Logger.LogInfo($"[t={_elapsed:F1}s] ── Phase 8: GpuMath Reductions (CPU fallback) ──", LoggingTarget.MainGame);

            if (_gpu == null) { Logger.LogError("  GpuMath not initialised — skipping.", LoggingTarget.MainGame); return; }

            var values = new float[] { 3f, 1f, 4f, 1f, 5f, 9f, 2f, 6f }; // Pi digits ≈ fun

            float sum = _gpu.Sum(values);
            float min = _gpu.Min(values);
            float max = _gpu.Max(values);
            Logger.LogInfo($"  Data   : [{string.Join(", ", values)}]", LoggingTarget.MainGame);
            Logger.LogInfo($"  Sum    : {sum}  (expected 31)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Min    : {min}  (expected 1)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Max    : {max}  (expected 9)", LoggingTarget.MainGame);

            // Vec2 reductions
            var vecs = new[]
            {
                new Vec2(1f, 2f), new Vec2(3f, 4f),
                new Vec2(5f, 6f), new Vec2(7f, 8f)
            };
            var vecSum = _gpu.Sum(vecs);
            var vecAvg = _gpu.Average(vecs);
            Logger.LogInfo($"  Vec2 Sum     = ({vecSum.X}, {vecSum.Y})  (expected 16, 20)", LoggingTarget.MainGame);
            Logger.LogInfo($"  Vec2 Average = ({vecAvg.X}, {vecAvg.Y})  (expected 4, 5)", LoggingTarget.MainGame);

            Assert(MathF.Abs(sum - 31f) < 1e-4f, "GpuMath Sum");
            Assert(MathF.Abs(min - 1f) < 1e-4f, "GpuMath Min");
            Assert(MathF.Abs(max - 9f) < 1e-4f, "GpuMath Max");
            Assert(MathF.Abs(vecSum.X - 16f) < 1e-4f, "GpuMath Vec2 Sum X");
            Assert(MathF.Abs(vecAvg.Y - 5f) < 1e-4f, "GpuMath Vec2 Average Y");
            Logger.LogInfo("  Phase 8 OK.", LoggingTarget.MainGame);
        }

        // ── Helpers ──────────────────────────────────────────────────────────

        private static void Assert(bool condition, string label)
        {
            if (!condition)
                Logger.LogError($"  ASSERTION FAILED: {label}", LoggingTarget.MainGame);
        }

        // ── IScreenPlay boilerplate ───────────────────────────────────────────

        public void LateUpdate(double dt) { }
        public void OnDraw() { }
        public void OnMessage(IntPtr msg) { }

        public void Render() { }

        public void Cleanup()
        {
            Logger.LogInfo("MathTestScript: Cleanup()", LoggingTarget.MainGame);
            _gpu?.Dispose();
            _gpu = null;
        }
    }
}
