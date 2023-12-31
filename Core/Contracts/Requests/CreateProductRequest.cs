﻿namespace Microservice.Food.Core.Contracts.Requests;

public sealed class CreateProductRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public required decimal Discount { get; init; }
    public required decimal Price { get; init; }
}
