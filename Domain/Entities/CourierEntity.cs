using ArchitectProg.Kernel.Extensions.Entities;

namespace Microservice.Food.Domain.Entities;

public class CourierEntity : Entity<int>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public ICollection<OrderEntity> Orders { get; } = new List<OrderEntity>();
}
