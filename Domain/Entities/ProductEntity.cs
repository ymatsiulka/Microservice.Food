using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class ProductEntity : Entity<int>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public decimal Discount { get; set; }
    public decimal Price { get; set; }

    public required ICollection<CategoryEntity> Categories { get; init; } 
}
