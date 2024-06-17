#if DEBUG
using BenchmarkDotNet.Configs;
#endif
using BenchmarkDotNet.Running;
using HeapStack.Benchmarker.Services;

namespace HeapStack.Benchmarker;

internal class Program
{
    private static void Main(string[] args)
    {
#if DEBUG
        var summary = BenchmarkRunner.Run<NumberTypeBenchmarker>(new DebugBuildConfig());
#else
        var summary = BenchmarkRunner.Run<NumberTypeBenchmarker>();
#endif
    }
}
