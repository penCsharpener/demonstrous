using BenchmarkDotNet.Attributes;
using HeapStack.WorkerService.Models;

namespace HeapStack.Benchmarker.Services;

[MemoryDiagnoser]
public class ClassStructRecordBenchmarker
{
    /*
| Method       | Mean       | Error    | StdDev   | Gen0      | Allocated  |
|------------- |-----------:|---------:|---------:|----------:|-----------:|
| Class        | 4,332.9 us | 51.19 us | 47.89 us | 2875.0000 | 24048075 B |
| Struct       |   931.4 us |  3.72 us |  3.48 us |         - |       72 B |
| Record       | 4,197.0 us | 72.70 us | 68.01 us | 2875.0000 | 24048075 B |
| RecordStruct |   935.8 us |  8.34 us |  7.40 us |         - |       72 B |
     */

    private readonly IEnumerable<string> _names;

    public ClassStructRecordBenchmarker()
    {
        _names = Enumerable.Range(1, 1000).Select(x => "test").ToList();
    }

    [Benchmark]
    public void Class()
    {
        var items = _names.Select(x => new PersonClass() { Name = x });

        for (var i = 0; i < items.Count(); i++)
        {
            var x = items.ElementAt(i).Name;
        }
    }

    [Benchmark]
    public void Struct()
    {
        var items = _names.Select(x => new PersonStruct() { Name = x });

        for (var i = 0; i < items.Count(); i++)
        {
            var x = items.ElementAt(i).Name;
        }
    }

    [Benchmark]
    public void Record()
    {
        var items = _names.Select(x => new PersonRecord() { Name = x });

        for (var i = 0; i < items.Count(); i++)
        {
            var x = items.ElementAt(i).Name;
        }
    }

    [Benchmark]
    public void RecordStruct()
    {
        var items = _names.Select(x => new PersonRecordStruct() { Name = x });

        for (var i = 0; i < items.Count(); i++)
        {
            var x = items.ElementAt(i).Name;
        }
    }
}