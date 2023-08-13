namespace Microservice.Food.Core.Contracts.Responses;

public class ProductResponse
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public decimal Discount { get; init; }
    public decimal Price { get; init; }
}
