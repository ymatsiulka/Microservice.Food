using ArchitectProg.FunctionalExtensions.Factories.Interfaces;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers;

public sealed class OrderMapper : IOrderMapper
{
    private readonly IEnumItemFactory enumItemFactory;

    public OrderMapper(IEnumItemFactory enumItemFactory)
    {
        this.enumItemFactory = enumItemFactory;
    }

    public OrderResponse Map(OrderEntity source)
    {
        var result = new OrderResponse
        {
            Id = source.Id,
            Status = enumItemFactory.GetEnumItem(source.Status),
            Description = source.Description,
            CreatedAt = source.CreatedAt,
            UpdatedAt = source.UpdatedAt,
            Total = source.Total
        };

        return result;
    }
}
