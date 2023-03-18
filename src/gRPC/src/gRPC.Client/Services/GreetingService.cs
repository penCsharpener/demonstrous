using Grpc.Core;
using gRPC.Service;
using Microsoft.Extensions.Logging;
using static gRPC.Service.Greeter;

namespace gRPC.Client.Services;

public class GreetingService : GreeterBase
{
    private readonly ILogger<GreetingService> _logger;

    public GreetingService(ILogger<GreetingService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        if (!request.Successful)
        {
            _logger.LogWarning("{className}.{methodName}: That didn't go well.", nameof(GreetingService), nameof(SayHello));
        }

        Console.WriteLine($"Person spoke in a {request.MoodType.ToString()} mood.");

        foreach (var info in request.Infos)
        {
            Console.WriteLine($"Do something with {info} at {request.Timestamp.ToDateTime()}.");
        }

        return Task.FromResult(new HelloReply()
        {
            MoodType = Mood.Happy,
            Message = "All is well"
        });
    }
}