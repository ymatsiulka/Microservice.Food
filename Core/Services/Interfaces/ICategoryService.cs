using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryResponse> Create(CreateCategoryRequest request);
    Task Update(int categoryId, UpdateCategoryRequest request);
    Task Delete(int categoryId);
    Task<CategoryResponse> Get(int categoryId);
}
