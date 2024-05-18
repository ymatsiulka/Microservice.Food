using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IProductCategoryService
{
    Task<ProductCategoryResponse> Create(int productId, int categoryId);
    Task Delete(int productId, int categoryId);
}
