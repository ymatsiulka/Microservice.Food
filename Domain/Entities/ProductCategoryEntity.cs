using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class ProductCategoryEntity : Entity<int>
{
    public int ProductId { get; init; }
    public required ProductEntity Product { get; init; }
    public int CategoryId { get; init; }
    public required CategoryEntity Category { get; init; }
}
