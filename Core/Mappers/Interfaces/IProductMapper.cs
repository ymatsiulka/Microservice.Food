using ArchitectProg.Kernel.Extensions.Mappers.Interfaces;
using Microservice.Food.Core.Contracts.Responses;
using Microservice.Food.Domain.Entities;

namespace Microservice.Food.Core.Mappers.Interfaces;

public interface IProductMapper : IMapper<ProductEntity, ProductResponse>
{
}
