using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class ProductEntity : Entity<int>
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public decimal Discount { get; init; }
    public decimal Price { get; init; }

    public required ICollection<CategoryEntity> Categories { get; init; }
}
