using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IProductService
{
    Task<ProductResponse> Create(CreateProductRequest request);
    Task Update(int productId, UpdateProductRequest request);
    Task Delete(int productId);
    Task<ProductResponse> Get(int productId);
}
