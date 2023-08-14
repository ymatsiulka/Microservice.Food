using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IProductCategoryService
{
    Task<Result<ProductCategoryResponse>> Create(int productId, int categoryId);
    Task<Result> Delete(int productId, int categoryId);
}
