using Angene.Main;
using Angene.Math.Defs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Stub IComputeBackend that satisfies the constructor contract for GpuMath.
    /// All demo arrays are kept below GpuMath.GpuThreshold (512), so the CPU
    /// fallback path runs and this backend is never actually dispatched.
    /// If a test accidentally exceeds the threshold it will throw clearly rather
    /// than silently doing nothing.
    /// 
    /// At compile time for Angene.Math creation, IComputeBackend was not created.
    /// </summary>
    internal sealed class NullComputeBackend : IComputeBackend
    {
        public IComputeJob<TIn, TOut> CreateJob<TIn, TOut>(string shaderSource, int maxElements)
            where TIn : unmanaged
            where TOut : unmanaged
        {
            throw new AngeneException(
                "NullComputeBackend: GPU dispatch was attempted. " +
                "Increase GpuThreshold or reduce the array size to stay on the CPU fallback path.");
        }

        public void Flush() { }

        public void Dispose() { }
    }
}
