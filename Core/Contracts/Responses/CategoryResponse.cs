namespace Microservice.Food.Core.Contracts.Responses;

public sealed class CategoryResponse
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}
