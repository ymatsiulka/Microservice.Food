using ArchitectProg.Kernel.Extensions.Mappers;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers;

public sealed class ProductMapper : Mapper<ProductEntity, ProductResponse>, IProductMapper
{
    public override ProductResponse Map(ProductEntity source)
    {
        var result = new ProductResponse
        {
            Id = source.Id,
            Description = source.Description,
            Discount = source.Discount,
            ImageUrl = source.ImageUrl,
            Name = source.Name,
            Price = source.Price
        };

        return result;
    }
}
