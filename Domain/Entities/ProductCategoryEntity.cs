using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class ProductCategoryEntity : Entity<int>
{
    public int ProductId { get; init; }
    public ProductEntity Product { get; set; } = null!;

    public int CategoryId { get; init; }
    public CategoryEntity Category { get; set; } = null!;
}
