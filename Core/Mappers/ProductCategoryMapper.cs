using ArchitectProg.Kernel.Extensions.Mappers;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers;

public sealed class ProductCategoryMapper : Mapper<ProductCategoryEntity, ProductCategoryResponse>, IProductCategoryMapper
{
    private readonly ICategoryMapper categoryMapper;
    private readonly IProductMapper productMapper;

    public ProductCategoryMapper(ICategoryMapper categoryMapper, IProductMapper productMapper)
    {
        this.categoryMapper = categoryMapper;
        this.productMapper = productMapper;
    }

    public override ProductCategoryResponse Map(ProductCategoryEntity source)
    {
        var result = new ProductCategoryResponse
        {
            Category = categoryMapper.Map(source.Category),
            Product = productMapper.Map(source.Product),
        };

        return result;
    }
}
