namespace Microservice.Food.Core.Contracts.Requests;

public sealed class UpdateCategoryRequest
{
    public required int Id { get; init; }
    public required string Name { get; init; }
}
