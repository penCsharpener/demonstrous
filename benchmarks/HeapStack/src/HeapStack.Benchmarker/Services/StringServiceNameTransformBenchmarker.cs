using BenchmarkDotNet.Attributes;
using HeapStack.WorkerService.Services;

namespace HeapStack.Benchmarker.Services;

[MemoryDiagnoser]
public class StringServiceNameTransformBenchmarker
{
    private readonly StringService _sut = new();
    private const string _name = "Toub, Stephen";

    [Benchmark]
    public void Bad()
    {
        var (first, last) = _sut.NameTransformSubstring(_name);
    }

    [Benchmark]
    public void Good()
    {
        var (first, last) = _sut.NameTransformSplit(_name);
    }

    [Benchmark]
    public void Better()
    {
        var (first, last) = _sut.NameTransformSpan(_name);
    }
}