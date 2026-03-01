using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Audio.Common
{
    internal class AudioDefs
    {
        internal readonly record struct AudioCommand(AudioCommandType Type, float Value = 0f);

        internal enum AudioCommandType
        {
            Play, Stop, Pause, Resume, Volume, Loop, Dispose
        }
    }
}
