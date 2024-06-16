using Generics.WorkerService.Abstractions;
using Generics.WorkerService.Handler;

namespace Generics.WorkerService.Tests;

public class WorkerTests
{
    private readonly Worker _sut;

    public WorkerTests(Worker sut)
    {
        _sut = sut;
    }

    [Fact]
    public void Test1()
    {

    }
}

public class ReflectionDiscoveryTests
{
    [Fact]
    public void Get_Example_Handlers_By_Request()
    {
        Type requestGenericType = typeof(IRequest<>);
        Type requestType = typeof(ExampleRequest);
        Type responseType = typeof(ExampleResponse);

        Type handlerType = typeof(IHandler<,>);
        Type sd = typeof(ExampleHandler);
        // WIP:
        IEnumerable<Type> handler = handlerType.Assembly
            .GetTypes().Where(t => //t.IsAssignableFrom(handlerType) && 
                                   t.GetInterfaces().Any(i => i.IsGenericType &&
                                   i.IsAssignableFrom(handlerType) &&
                                   i.GetGenericTypeDefinition() == handlerType)).ToList();
    }
}