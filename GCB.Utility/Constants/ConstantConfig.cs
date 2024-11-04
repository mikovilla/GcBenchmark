using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.Utility.Constants
{
    public static class ConstantConfig
    {
        private static readonly int NumberOfLoopsMultiplier = 8;
        public static readonly int NumberOfLoops = short.MaxValue * NumberOfLoopsMultiplier;
        public static readonly int PauseAfterNthOperation = 4096;
        public static readonly int PauseTime = NumberOfLoopsMultiplier < 6 ? 1 : 2;
    }
}
