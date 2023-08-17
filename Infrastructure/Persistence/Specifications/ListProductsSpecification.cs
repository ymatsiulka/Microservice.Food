using ArchitectProg.Kernel.Extensions.Specifications;
using Microservice.Food.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Food.Infrastructure.Persistence.Specifications;

public sealed class ListProductsSpecification : Specification<ProductEntity>
{
    private readonly int[] productIds;

    public ListProductsSpecification(int[] productIds)
    {
        this.productIds = productIds ?? throw new ArgumentNullException(nameof(productIds));
    }

    public override IQueryable<ProductEntity> AddPredicates(
         IQueryable<ProductEntity> query)
    {
        var result = query.Where(x => productIds.Contains(x.Id));
        return result;
    }
}
