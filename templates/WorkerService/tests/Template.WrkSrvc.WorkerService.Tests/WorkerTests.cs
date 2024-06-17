using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Template.WrkSrvc.WorkerService.Tests;

public class WorkerTests
{
    private readonly Worker _sut;
    private readonly IHostApplicationLifetime _hosting;
    private readonly ILogger<Worker> _logger;

    public WorkerTests()
    {
        _hosting = Substitute.For<IHostApplicationLifetime>();
        _logger = Substitute.For<ILogger<Worker>>();

        _sut = new Worker(_hosting, _logger);
    }

    [Fact]
    public void Test1()
    {

    }
}