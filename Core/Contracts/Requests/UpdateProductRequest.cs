namespace Microservice.Food.Core.Contracts.Requests;

public class UpdateProductRequest
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public required decimal Discount { get; init; }
    public required decimal Price { get; init; }
}
