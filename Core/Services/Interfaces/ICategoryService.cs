using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<Result<CategoryResponse>> Create(CreateCategoryRequest request);
    Task<Result> Update(int categoryId, UpdateCategoryRequest request);
    Task<Result> Delete(int categoryId);
    Task<Result<CategoryResponse>> Get(int categoryId);
}
