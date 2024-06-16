using Generics.WorkerService.Abstractions;

namespace Generics.WorkerService.Handler;

public class ExampleRequest : IRequest<ExampleResponse>
{

}

public class ExampleResponse : IResponse
{

}

internal class ExampleHandler : IHandler<ExampleRequest, ExampleResponse>
{
    public Task<ExampleResponse> HandleAsync(ExampleRequest request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
