using ArchitectProg.FunctionalExtensions.Contracts;

namespace Microservice.Food.Core.Contracts.Responses;

public class OrderResponse
{
    public int Id { get; set; }
    public string? Description { get; init; }
    public decimal Total { get; init; }
    public required EnumItem Status { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
}
