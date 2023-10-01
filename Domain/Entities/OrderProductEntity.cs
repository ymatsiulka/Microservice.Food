using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class OrderProductEntity : Entity<long>
{
    public required string ProductName { get; init; }
    public decimal Price  { get; init; }
    public decimal Discount  { get; init; }

    public int OrderId { get; init; }
    public required OrderEntity Order { get; init; }

    
    public int ProductId { get; init; }
    public required ProductEntity Product { get; init; }
}
