using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class Category : Entity<int>
{
    public required string Name { get; init; }
    public required ICollection<Product> Products { get; init; }
}
