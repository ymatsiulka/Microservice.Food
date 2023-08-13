using ArchitectProg.Kernel.Extensions.Mappers;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Core.Mappers.Interfaces;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers;

public sealed class CategoryMapper : Mapper<CategoryEntity, CategoryResponse>, ICategoryMapper
{
    public override CategoryResponse Map(CategoryEntity source)
    {
        var result = new CategoryResponse
        {
            Id = source.Id,
            Name = source.Name
        };

        return result;
    }
}
