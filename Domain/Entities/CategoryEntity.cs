using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class CategoryEntity : Entity<int>
{
    public required string Name { get; init; }
    public required ICollection<ProductEntity> Products { get; init; }
}
