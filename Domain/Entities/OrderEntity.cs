using ArchitectProg.Kernel.Extensions.Entities;
using Microservice.Food.Domain.Enums;

namespace Microservice.Food.Domain.Entities;

public class OrderEntity : Entity<int>
{
    public required string Description { get; init; }
    public decimal Total { get; init; }
    public OrderStatus Status { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }

    public required ICollection<OrderProductEntity> OrderProducts { get; init; }
}
