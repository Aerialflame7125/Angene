using Angene.Math;
using Angene.Math.Defs;
using Angene.Math.Vectors;
using Angene.Math.Interpolation;
using System.Runtime.InteropServices;
using Angene.Common;

namespace Angene.Math.GPU
{
    // Sadly also majorly vibe coded. This is territory I have almost never interacted with in the past, nor probably will in the future.
    public class Math : IDisposable
    {
        private readonly IComputeBackend _backend;
        private bool _disposed;

        public int GpuThreshold { get; set; } = 512; // below this, falls back to CPU

        public Math(IComputeBackend backend)
        {
            _backend = backend ?? throw new Common.AngeneException("GpuMath requires a valid IComputeBackend.");
        }

        // --- Vec2 bulk ops ---

        public Vec2[] Add(Vec2[] a, Vec2[] b)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Add: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new Vec2[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = a[i] + b[i];
                return r;
            }

            var job = _backend.CreateJob<Vec2Pair, Vec2>(@"
                struct Vec2Pair { float2 A; float2 B; };
                RWStructuredBuffer<Vec2Pair> Input  : register(u0);
                RWStructuredBuffer<float2>   Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = Input[id.x].A + Input[id.x].B;
                }", a.Length);

            var pairs = new Vec2Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec2Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        public Vec2[] Scale(Vec2[] vectors, float scalar)
        {
            if (vectors.Length < GpuThreshold)
            {
                var r = new Vec2[vectors.Length];
                for (int i = 0; i < vectors.Length; i++) r[i] = vectors[i] * scalar;
                return r;
            }

            var job = _backend.CreateJob<Vec2, Vec2>(@"
                RWStructuredBuffer<float2> Input  : register(u0);
                RWStructuredBuffer<float2> Output : register(u1);
                cbuffer Constants : register(b0) { float Scalar; };
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = Input[id.x] * Scalar;
                }", vectors.Length);

            job.Upload(vectors);
            job.Dispatch();
            return job.Collect();
        }

        public Vec2[] Normalize(Vec2[] vectors)
        {
            if (vectors.Length < GpuThreshold)
            {
                var r = new Vec2[vectors.Length];
                for (int i = 0; i < vectors.Length; i++) r[i] = vectors[i].Normalized;
                return r;
            }

            var job = _backend.CreateJob<Vec2, Vec2>(@"
                RWStructuredBuffer<float2> Input  : register(u0);
                RWStructuredBuffer<float2> Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = normalize(Input[id.x]);
                }", vectors.Length);

            job.Upload(vectors);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Dot(Vec2[] a, Vec2[] b)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Dot: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new float[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = Vec2.Dot(a[i], b[i]);
                return r;
            }

            var job = _backend.CreateJob<Vec2Pair, float>(@"
                struct Vec2Pair { float2 A; float2 B; };
                RWStructuredBuffer<Vec2Pair> Input  : register(u0);
                RWStructuredBuffer<float>    Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = dot(Input[id.x].A, Input[id.x].B);
                }", a.Length);

            var pairs = new Vec2Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec2Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Length(Vec2[] vectors)
        {
            if (vectors.Length < GpuThreshold)
            {
                var r = new float[vectors.Length];
                for (int i = 0; i < vectors.Length; i++) r[i] = vectors[i].Length;
                return r;
            }

            var job = _backend.CreateJob<Vec2, float>(@"
                RWStructuredBuffer<float2> Input  : register(u0);
                RWStructuredBuffer<float>  Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = length(Input[id.x]);
                }", vectors.Length);

            job.Upload(vectors);
            job.Dispatch();
            return job.Collect();
        }

        public Vec2[] Lerp(Vec2[] a, Vec2[] b, float t)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Lerp: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new Vec2[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = Vec2.Lerp(a[i], b[i], t);
                return r;
            }

            var job = _backend.CreateJob<Vec2Pair, Vec2>(@"
                struct Vec2Pair { float2 A; float2 B; };
                RWStructuredBuffer<Vec2Pair> Input  : register(u0);
                RWStructuredBuffer<float2>   Output : register(u1);
                cbuffer Constants : register(b0) { float T; };
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = lerp(Input[id.x].A, Input[id.x].B, T);
                }", a.Length);

            var pairs = new Vec2Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec2Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        public Vec2[] Lerp(Vec2[] a, Vec2[] b, float[] t)
        {
            if (a.Length != b.Length || a.Length != t.Length)
                throw new Common.AngeneException("GpuMath.Lerp: all arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new Vec2[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = Vec2.Lerp(a[i], b[i], t[i]);
                return r;
            }

            var job = _backend.CreateJob<Vec2PairT, Vec2>(@"
                struct Vec2PairT { float2 A; float2 B; float T; float _pad; };
                RWStructuredBuffer<Vec2PairT> Input  : register(u0);
                RWStructuredBuffer<float2>    Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = lerp(Input[id.x].A, Input[id.x].B, Input[id.x].T);
                }", a.Length);

            var pairs = new Vec2PairT[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec2PairT { A = a[i], B = b[i], T = t[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        // --- Vec3 bulk ops ---

        public Vec3[] Add(Vec3[] a, Vec3[] b)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Add: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new Vec3[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = a[i] + b[i];
                return r;
            }

            var job = _backend.CreateJob<Vec3Pair, Vec3>(@"
                struct Vec3Pair { float3 A; float _padA; float3 B; float _padB; };
                RWStructuredBuffer<Vec3Pair> Input  : register(u0);
                RWStructuredBuffer<float3>   Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = Input[id.x].A + Input[id.x].B;
                }", a.Length);

            var pairs = new Vec3Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec3Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        public Vec3[] Cross(Vec3[] a, Vec3[] b)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Cross: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new Vec3[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = Vec3.Cross(a[i], b[i]);
                return r;
            }

            var job = _backend.CreateJob<Vec3Pair, Vec3>(@"
                struct Vec3Pair { float3 A; float _padA; float3 B; float _padB; };
                RWStructuredBuffer<Vec3Pair> Input  : register(u0);
                RWStructuredBuffer<float3>   Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = cross(Input[id.x].A, Input[id.x].B);
                }", a.Length);

            var pairs = new Vec3Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec3Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        public Vec3[] Normalize(Vec3[] vectors)
        {
            if (vectors.Length < GpuThreshold)
            {
                var r = new Vec3[vectors.Length];
                for (int i = 0; i < vectors.Length; i++) r[i] = vectors[i].Normalized;
                return r;
            }

            var job = _backend.CreateJob<Vec3, Vec3>(@"
                RWStructuredBuffer<float3> Input  : register(u0);
                RWStructuredBuffer<float3> Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = normalize(Input[id.x]);
                }", vectors.Length);

            job.Upload(vectors);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Dot(Vec3[] a, Vec3[] b)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Dot: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new float[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = Vec3.Dot(a[i], b[i]);
                return r;
            }

            var job = _backend.CreateJob<Vec3Pair, float>(@"
                struct Vec3Pair { float3 A; float _padA; float3 B; float _padB; };
                RWStructuredBuffer<Vec3Pair> Input  : register(u0);
                RWStructuredBuffer<float>    Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = dot(Input[id.x].A, Input[id.x].B);
                }", a.Length);

            var pairs = new Vec3Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Vec3Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        // --- Matrix bulk ops ---

        public Vec2[] Transform(Matrix3x3 matrix, Vec2[] points)
        {
            if (points.Length < GpuThreshold)
            {
                var r = new Vec2[points.Length];
                for (int i = 0; i < points.Length; i++) r[i] = matrix * points[i];
                return r;
            }

            var job = _backend.CreateJob<Vec2, Vec2>(@"
                RWStructuredBuffer<float2> Input  : register(u0);
                RWStructuredBuffer<float2> Output : register(u1);
                cbuffer Constants : register(b0) {
                    row_major float3x3 Matrix;
                };
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    float3 p = float3(Input[id.x].xy, 1.0);
                    float3 t = mul(Matrix, p);
                    Output[id.x] = t.xy;
                }", points.Length);

            job.Upload(points);
            job.Dispatch();
            return job.Collect();
        }

        public Matrix3x3[] Multiply(Matrix3x3[] a, Matrix3x3[] b)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Multiply: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new Matrix3x3[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = a[i] * b[i];
                return r;
            }

            var job = _backend.CreateJob<Matrix3x3Pair, Matrix3x3>(@"
                struct Mat3 { float3 R0; float _p0; float3 R1; float _p1; float3 R2; float _p2; };
                struct Mat3Pair { Mat3 A; Mat3 B; };
                RWStructuredBuffer<Mat3Pair> Input  : register(u0);
                RWStructuredBuffer<Mat3>     Output : register(u1);
                float3x3 Unpack(Mat3 m) { return float3x3(m.R0, m.R1, m.R2); }
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    float3x3 result = mul(Unpack(Input[id.x].A), Unpack(Input[id.x].B));
                    Output[id.x].R0 = result[0]; Output[id.x].R1 = result[1]; Output[id.x].R2 = result[2];
                }", a.Length);

            var pairs = new Matrix3x3Pair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new Matrix3x3Pair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        // --- Scalar bulk ops ---

        public float[] Clamp(float[] values, float min, float max)
        {
            if (values.Length < GpuThreshold)
            {
                var r = new float[values.Length];
                for (int i = 0; i < values.Length; i++) r[i] = Mathf.Clamp(values[i], min, max);
                return r;
            }

            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                cbuffer Constants : register(b0) { float Min; float Max; };
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = clamp(Input[id.x], Min, Max);
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Lerp(float[] a, float[] b, float t)
        {
            if (a.Length != b.Length)
                throw new Common.AngeneException("GpuMath.Lerp: arrays must be equal length.");

            if (a.Length < GpuThreshold)
            {
                var r = new float[a.Length];
                for (int i = 0; i < a.Length; i++) r[i] = Mathf.Lerp(a[i], b[i], t);
                return r;
            }

            var job = _backend.CreateJob<FloatPair, float>(@"
                struct FloatPair { float A; float B; };
                RWStructuredBuffer<FloatPair> Input  : register(u0);
                RWStructuredBuffer<float>     Output : register(u1);
                cbuffer Constants : register(b0) { float T; };
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = lerp(Input[id.x].A, Input[id.x].B, T);
                }", a.Length);

            var pairs = new FloatPair[a.Length];
            for (int i = 0; i < a.Length; i++) pairs[i] = new FloatPair { A = a[i], B = b[i] };
            job.Upload(pairs);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Remap(float[] values, float inMin, float inMax, float outMin, float outMax)
        {
            if (values.Length < GpuThreshold)
            {
                var r = new float[values.Length];
                for (int i = 0; i < values.Length; i++) r[i] = Mathf.Remap(values[i], inMin, inMax, outMin, outMax);
                return r;
            }

            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                cbuffer Constants : register(b0) { float InMin; float InMax; float OutMin; float OutMax; };
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    float t = (Input[id.x] - InMin) / (InMax - InMin);
                    Output[id.x] = lerp(OutMin, OutMax, saturate(t));
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Sqrt(float[] values)
        {
            if (values.Length < GpuThreshold)
            {
                var r = new float[values.Length];
                for (int i = 0; i < values.Length; i++) r[i] = MathF.Sqrt(values[i]);
                return r;
            }

            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = sqrt(Input[id.x]);
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            return job.Collect();
        }

        public float[] Abs(float[] values)
        {
            if (values.Length < GpuThreshold)
            {
                var r = new float[values.Length];
                for (int i = 0; i < values.Length; i++) r[i] = MathF.Abs(values[i]);
                return r;
            }

            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID) {
                    Output[id.x] = abs(Input[id.x]);
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            return job.Collect();
        }

        // --- Reductions ---

        public float Sum(float[] values)
        {
            if (values.Length < GpuThreshold)
            {
                float s = 0; foreach (var v in values) s += v; return s;
            }
            // GPU parallel reduce — collect single float back
            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                groupshared float shared[64];
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID, uint gi : SV_GroupIndex) {
                    shared[gi] = Input[id.x];
                    GroupMemoryBarrierWithGroupSync();
                    for (uint s = 32; s > 0; s >>= 1) {
                        if (gi < s) shared[gi] += shared[gi + s];
                        GroupMemoryBarrierWithGroupSync();
                    }
                    if (gi == 0) Output[id.x / 64] = shared[0];
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            var partials = job.Collect();
            float total = 0; foreach (var p in partials) total += p;
            return total;
        }

        public float Min(float[] values)
        {
            if (values.Length < GpuThreshold)
            {
                float m = float.MaxValue; foreach (var v in values) if (v < m) m = v; return m;
            }

            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                groupshared float shared[64];
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID, uint gi : SV_GroupIndex) {
                    shared[gi] = Input[id.x];
                    GroupMemoryBarrierWithGroupSync();
                    for (uint s = 32; s > 0; s >>= 1) {
                        if (gi < s) shared[gi] = min(shared[gi], shared[gi + s]);
                        GroupMemoryBarrierWithGroupSync();
                    }
                    if (gi == 0) Output[id.x / 64] = shared[0];
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            var partials = job.Collect();
            float result = float.MaxValue; foreach (var p in partials) if (p < result) result = p;
            return result;
        }

        public float Max(float[] values)
        {
            if (values.Length < GpuThreshold)
            {
                float m = float.MinValue; foreach (var v in values) if (v > m) m = v; return m;
            }

            var job = _backend.CreateJob<float, float>(@"
                RWStructuredBuffer<float> Input  : register(u0);
                RWStructuredBuffer<float> Output : register(u1);
                groupshared float shared[64];
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID, uint gi : SV_GroupIndex) {
                    shared[gi] = Input[id.x];
                    GroupMemoryBarrierWithGroupSync();
                    for (uint s = 32; s > 0; s >>= 1) {
                        if (gi < s) shared[gi] = max(shared[gi], shared[gi + s]);
                        GroupMemoryBarrierWithGroupSync();
                    }
                    if (gi == 0) Output[id.x / 64] = shared[0];
                }", values.Length);

            job.Upload(values);
            job.Dispatch();
            var partials = job.Collect();
            float result = float.MinValue; foreach (var p in partials) if (p > result) result = p;
            return result;
        }

        public Vec2 Sum(Vec2[] vectors)
        {
            if (vectors.Length < GpuThreshold)
            {
                var s = Vec2.Zero; foreach (var v in vectors) s = s + v; return s;
            }

            var job = _backend.CreateJob<Vec2, Vec2>(@"
                RWStructuredBuffer<float2> Input  : register(u0);
                RWStructuredBuffer<float2> Output : register(u1);
                groupshared float2 shared[64];
                [numthreads(64,1,1)]
                void CSMain(uint3 id : SV_DispatchThreadID, uint gi : SV_GroupIndex) {
                    shared[gi] = Input[id.x];
                    GroupMemoryBarrierWithGroupSync();
                    for (uint s = 32; s > 0; s >>= 1) {
                        if (gi < s) shared[gi] += shared[gi + s];
                        GroupMemoryBarrierWithGroupSync();
                    }
                    if (gi == 0) Output[id.x / 64] = shared[0];
                }", vectors.Length);

            job.Upload(vectors);
            job.Dispatch();
            var partials = job.Collect();
            var total = Vec2.Zero; foreach (var p in partials) total = total + p;
            return total;
        }

        public Vec2 Average(Vec2[] vectors)
        {
            if (vectors.Length == 0)
                throw new Common.AngeneException("GpuMath.Average: cannot average empty array.");
            return Sum(vectors) / vectors.Length;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _backend?.Dispose();
            _disposed = true;
        }

        // --- Internal transfer structs (blittable, GPU-aligned) ---

        [StructLayout(LayoutKind.Sequential)]
        private struct Vec2Pair { public Vec2 A, B; }

        [StructLayout(LayoutKind.Sequential)]
        private struct Vec2PairT { public Vec2 A, B; public float T; public float _pad; }

        [StructLayout(LayoutKind.Sequential)]
        private struct Vec3Pair { public Vec3 A; public float _padA; public Vec3 B; public float _padB; }

        [StructLayout(LayoutKind.Sequential)]
        private struct FloatPair { public float A, B; }

        [StructLayout(LayoutKind.Sequential)]
        private struct Matrix3x3Pair { public Matrix3x3 A, B; }
    }
}