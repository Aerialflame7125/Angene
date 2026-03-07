using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Math.Defs
{
    public interface IComputeBackend : IDisposable
    {
        IComputeJob<TIn, TOut> CreateJob<TIn, TOut>(string shaderSource, int maxElements)
            where TIn : unmanaged
            where TOut : unmanaged;

        void Flush();
    }
}
