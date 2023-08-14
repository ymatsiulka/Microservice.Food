namespace Microservice.Food.Core.Contracts.Responses;

public sealed class ProductCategoryResponse
{
    public required CategoryResponse Category { get; init; }
    public required ProductResponse Product { get; init; }
}
