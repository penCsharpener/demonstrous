using BenchmarkDotNet.Attributes;

namespace HeapStack.Benchmarker.Services;

[MemoryDiagnoser]
public class CollectionAllocationBenchmarker
{
    /*
| Method | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| List   | 553.77 ns | 13.815 ns | 40.299 ns | 538.77 ns |  6.07 |    0.47 | 0.2661 | 0.0010 |    2232 B |        2.71 |
| Array  |  92.51 ns |  1.810 ns |  3.858 ns |  91.77 ns |  1.00 |    0.00 | 0.0985 |      - |     824 B |        1.00 |
     */

    [Benchmark]
    public void List()
    {
        var collection = new List<int>();

        for (var i = 0; i < 200; i++)
        {
            collection.Add(i);
        }
    }

    [Benchmark(Baseline = true)]
    public void Array()
    {
        var collection = new int[200];

        for (var i = 0; i < 200; i++)
        {
            collection[i] = i;
        }
    }
}
