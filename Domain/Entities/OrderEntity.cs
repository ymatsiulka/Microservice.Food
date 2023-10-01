using ArchitectProg.Kernel.Extensions.Entities;
using Microservice.Food.Domain.Enums;

namespace Microservice.Food.Domain.Entities;

public class OrderEntity : Entity<int>
{
    public string? Description { get; set; }
    public decimal Total { get; set; }
    
    public OrderStatus Status { get; set; }
    public DeliveryType DeliveryType { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public int? CourierId { get; set; }
    public CourierEntity? Courier { get; set; }

    public ICollection<OrderProductEntity> OrderProducts { get; } = new List<OrderProductEntity>();
}
