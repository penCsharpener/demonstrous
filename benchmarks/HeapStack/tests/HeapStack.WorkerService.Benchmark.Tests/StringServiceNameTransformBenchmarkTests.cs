using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using HeapStack.Benchmarker.Services;

namespace HeapStack.WorkerService.Benchmark.Tests;

public class StringServiceNameTransformBenchmarkTests
{
    private readonly Summary _summary;

    public StringServiceNameTransformBenchmarkTests()
    {
        _summary = BenchmarkRunner.Run<StringServiceNameTransformBenchmarker>();
    }

    [Fact]
    public void NameTransform_Span()
    {
        var mean = GetReport(_summary, "StringService.NameTransformSpan").Mean;

        mean.Should().BeInRange(0, 500, "Mean is " + mean);
    }

    public static Statistics GetReport(Summary summary, string key)
    {
        return summary.Reports.FirstOrDefault(x => string.Compare(x.BenchmarkCase.Descriptor.DisplayInfo, key, true) == 0)?.ResultStatistics!;
    }
}