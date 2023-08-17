namespace Microservice.Food.Core.Contracts.Requests;

public sealed class CreateOrderRequest
{
    public string? Description { get; init; }

    public required int[] ProductIds { get; init; }
}
