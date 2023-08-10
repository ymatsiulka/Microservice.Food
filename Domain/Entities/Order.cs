using ArchitectProg.Kernel.Extensions.Entities;
using Microservice.Food.Domain.Enums;
using Microservice.Food.Domain.ValueObjects;

namespace Microservice.Food.Domain.Entities;

public class Order : Entity<long>
{
    public DateTime CreatedAt { get; init; }

    public OrderStatus Status { get; init; }

    public decimal Total { get; init; }

    public required string Description { get; init; }

    public required Address DeliveryAddress { get; init; }

    public required ICollection<OrderProduct> OrderProducts { get; init; }
}
