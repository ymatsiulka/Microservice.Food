namespace Microservice.Food.Core.Contracts.Requests;

public sealed class CreateCategoryRequest
{
    public required string Name { get; init; }
}
