using ArchitectProg.Kernel.Extensions.Utils;
using Microservice.Food.Core.Contracts.Requests;
using Microservice.Food.Core.Contracts.Responses;

namespace Microservice.Food.Core.Services.Interfaces;

public interface IProductService
{
    Task<Result<ProductResponse>> Create(CreateProductRequest request);
    Task<Result> Update(int productId, UpdateProductRequest request);
    Task<Result> Delete(int productId);
    Task<Result<ProductResponse>> Get(int productId);
}
