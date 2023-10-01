namespace Microservice.Food.Domain.Entities;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }

    string Action { get; set; }
}
