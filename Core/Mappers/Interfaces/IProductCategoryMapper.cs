using ArchitectProg.Kernel.Extensions.Mappers;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers.Interfaces;

public interface IProductCategoryMapper : IMapper<ProductCategoryEntity, ProductCategoryResponse>
{
}
