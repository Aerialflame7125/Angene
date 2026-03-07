using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Math.Defs
{
    public interface IComputeJob<TInput, TOutput> : IDisposable
    where TInput : unmanaged
    where TOutput : unmanaged
    {
        void Upload(TInput[] data);
        void Dispatch();
        TOutput[] Collect();   // Blocks until done — GPU readback
        bool IsComplete { get; }
    }
}
