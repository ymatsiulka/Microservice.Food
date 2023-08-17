using ArchitectProg.Kernel.Extensions.Specifications;
using Microservice.Food.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Food.Infrastructure.Persistence.Specifications;

public sealed class GetOrderProductSpecification : Specification<OrderProductEntity>
{
    private readonly int orderId;
    private readonly int productId;

    public GetOrderProductSpecification(int orderId, int productId)
    {
        this.orderId = orderId;
        this.productId = productId;
    }

    public override IQueryable<OrderProductEntity> AddEagerFetching(
         IQueryable<OrderProductEntity> query)
    {
        return query
            .Include(x => x.Order)
            .Include(x => x.Product);
    }

    public override IQueryable<OrderProductEntity> AddPredicates(
         IQueryable<OrderProductEntity> query)
    {
        var result = query.Where(x => x.OrderId == orderId && x.ProductId == productId);
        return result;
    }
}
