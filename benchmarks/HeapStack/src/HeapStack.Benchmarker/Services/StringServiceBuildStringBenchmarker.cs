using BenchmarkDotNet.Attributes;
using HeapStack.WorkerService.Services;

namespace HeapStack.Benchmarker.Services;

[MemoryDiagnoser]
public class StringServiceBuildStringBenchmarker
{
    private readonly StringService _sut = new();

    [Benchmark]
    public void Bad()
    {
        var result = _sut.BuildStringBadly("Hello");
    }

    [Benchmark]
    public void Good()
    {
        var result = _sut.BuildStringBetter("Hello");
    }

    [Benchmark]
    public void Better()
    {
        var result = _sut.BuildStringBetterWithChar("Hello");
    }
}
