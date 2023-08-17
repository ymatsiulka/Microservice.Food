namespace Microservice.Food.Core.Contracts.Responses;

public sealed class OrderProductResponse
{
    public long Id { get; init; }

    public decimal Price { get; init; }
    public decimal Discount { get; init; }

    public required OrderResponse Order { get; init; }
    public required ProductResponse Product { get; init; }
}
