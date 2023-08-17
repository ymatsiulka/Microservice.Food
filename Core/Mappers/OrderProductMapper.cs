using ArchitectProg.Kernel.Extensions.Mappers;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers;

public sealed class OrderProductMapper : Mapper<OrderProductEntity, OrderProductResponse>, IOrderProductMapper
{
    private readonly IOrderMapper orderMapper;
    private readonly IProductMapper productMapper;

    public OrderProductMapper(
        IOrderMapper orderMapper,
        IProductMapper productMapper)
    {
        this.orderMapper = orderMapper;
        this.productMapper = productMapper;
    }

    public override OrderProductResponse Map(OrderProductEntity source)
    {
        var result = new OrderProductResponse
        {
            Product = productMapper.Map(source.Product),
            Order = orderMapper.Map(source.Order),
        };

        return result;
    }
}
