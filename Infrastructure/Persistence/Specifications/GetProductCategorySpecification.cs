using ArchitectProg.Kernel.Extensions.Specifications;
using Microservice.Food.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Food.Infrastructure.Persistence.Specifications;

public sealed class GetProductCategorySpecification : Specification<ProductCategoryEntity>
{
    private readonly int productId;
    private readonly int categoryId;

    public GetProductCategorySpecification(int productId, int categoryId)
    {
        this.productId = productId;
        this.categoryId = categoryId;
    }

    public override IQueryable<ProductCategoryEntity> AddEagerFetching(
         IQueryable<ProductCategoryEntity> query)
    {
        return query
            .Include(x => x.Category)
            .Include(x => x.Product);
    }

    public override IQueryable<ProductCategoryEntity> AddPredicates(
         IQueryable<ProductCategoryEntity> query)
    {
        var result = query.Where(x => x.ProductId == productId && x.CategoryId == categoryId);
        return result;
    }
}
