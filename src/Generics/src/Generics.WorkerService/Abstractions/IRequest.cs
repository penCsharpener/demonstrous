namespace Generics.WorkerService.Abstractions;

// covariant out parameter TResponse, 'out' only permissable on interfaces before C# 9
public interface IRequest<TResponse> where TResponse : IResponse
{

}
