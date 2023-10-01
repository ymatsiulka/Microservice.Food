using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity where T : struct
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public required string Action { get; set; }
}
