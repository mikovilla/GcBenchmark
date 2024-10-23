using GCB.Utility.Extensions;
using System.Diagnostics;

namespace GCB.Utility.Instrumentations
{
    public class TimedAction
    {
        public static void DisplayActionExecuteTime(Action action)
        {
            "Starting Benchmark".DumpLine();
            Stopwatch stopwatch = Stopwatch.StartNew();
            action.Invoke();
            stopwatch.Stop();
            $"Action Execute Time: {stopwatch.ElapsedMilliseconds.MsToReadableTime()}".DumpLine();
            "Ending Benchmark".DumpLine();
        }
    }
}
