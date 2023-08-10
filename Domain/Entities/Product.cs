using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class Product : Entity<int>
{
    public required string Name { get; init; }

    public decimal Discount { get; set; }

    public required string PictureUrl { get; set; }

    public decimal UnitPrice { get; set; }

    public int Units { get; set; }

    public required ICollection<Category> Categories { get; init; }
}
