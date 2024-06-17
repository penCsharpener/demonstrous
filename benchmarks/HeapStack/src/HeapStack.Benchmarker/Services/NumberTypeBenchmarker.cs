using BenchmarkDotNet.Attributes;

namespace HeapStack.Benchmarker.Services;

[MemoryDiagnoser]
public class NumberTypeBenchmarker
{
    [Benchmark]
    public void TypeLong()
    {
        long x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }

    [Benchmark(Baseline = true)]
    public void TypeInt()
    {
        var x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }

    [Benchmark]
    public void TypeByte()
    {
        long x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }

    [Benchmark]
    public void TypeFloat()
    {
        short x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }

    [Benchmark]
    public void TypeDouble()
    {
        double x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }

    [Benchmark]
    public void TypeFakeDecimal()
    {
        const long multiplier = 100000000000;
        decimal x = 200;
        var pi = (long)(Math.PI * 100000000000);

        for (var i = 0; i < x; i++)
        {
            pi += i;
            pi++;
        }

        var result = pi / (double)multiplier;
    }

    [Benchmark]
    public void TypeDecimal()
    {
        decimal x = 200;

        for (var i = 0; i < x; i++)
        {
            var y = i;
            y++;
        }
    }
}
