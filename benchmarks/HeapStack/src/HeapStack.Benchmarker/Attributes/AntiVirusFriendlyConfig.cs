using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace HeapStack.Benchmarker.Attributes;

public class AntiVirusFriendlyConfigAttribute : ConfigAttribute
{
    public AntiVirusFriendlyConfigAttribute() : base(typeof(AntiVirusFriendlyConfig))
    {
    }
}

internal class AntiVirusFriendlyConfig : ManualConfig
{
    public AntiVirusFriendlyConfig()
    {
        AddJob(Job.MediumRun.WithToolchain(InProcessEmitToolchain.Instance));
    }
}
