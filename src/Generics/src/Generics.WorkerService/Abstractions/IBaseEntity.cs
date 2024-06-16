namespace Generics.WorkerService.Abstractions;

public interface IBaseEntity<TId> where TId : struct
{
    public TId Id { get; set; }
}
