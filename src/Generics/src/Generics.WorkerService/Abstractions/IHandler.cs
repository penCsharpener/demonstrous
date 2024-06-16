namespace Generics.WorkerService.Abstractions;

public interface IHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IResponse
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken token);
}