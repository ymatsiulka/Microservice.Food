using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class ProductCategory : Entity<int>
{
    public int ProductId { get; init; }
    public required Product Product { get; init; }
    public int CategoryId { get; init; }
    public required Category Category { get; init; }
}
