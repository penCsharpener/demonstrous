using Generics.WorkerService.Abstractions;

namespace Generics.WorkerService.Models;

public class BaseEntity(Guid id) : IBaseEntity<Guid>
{
    public Guid Id { get; set; } = id;
}
